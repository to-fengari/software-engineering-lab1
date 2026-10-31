using System.Drawing.Drawing2D;

namespace lab9
{
	public enum ChartKind { Pie, Bar, Line }

	// .NET 8 WinForms has no System.Windows.Forms.DataVisualization.Charting
	// (it was .NET Framework only), so the charts are drawn with GDI+ here.
	// Colours come from a validated categorical palette, assigned in fixed slot
	// order and never cycled; every slice and bar carries a direct label, which
	// is what makes the lighter hues readable against the surface.
	public class ChartPanel : Panel
	{
		private static readonly Color[] Series =
		{
			ColorTranslator.FromHtml("#2a78d6"),  // blue
			ColorTranslator.FromHtml("#eb6834"),  // orange
			ColorTranslator.FromHtml("#1baf7a"),  // aqua
			ColorTranslator.FromHtml("#eda100"),  // yellow
			ColorTranslator.FromHtml("#e87ba4"),  // magenta
			ColorTranslator.FromHtml("#008300"),  // green
			ColorTranslator.FromHtml("#6250d6"),  // violet
			ColorTranslator.FromHtml("#e34948"),  // red
		};

		private static readonly Color Surface   = ColorTranslator.FromHtml("#fcfcfb");
		private static readonly Color InkPrimary = ColorTranslator.FromHtml("#0b0b0b");
		private static readonly Color InkMuted   = ColorTranslator.FromHtml("#52514e");
		private static readonly Color Grid       = ColorTranslator.FromHtml("#e4e3e0");

		public ChartKind Kind { get; set; } = ChartKind.Bar;
		public string Caption { get; set; } = "";
		public List<KeyValuePair<string, double>> Data { get; private set; } = new();

		public ChartPanel()
		{
			DoubleBuffered = true;
			BackColor = Surface;
			BorderStyle = BorderStyle.FixedSingle;
		}

		public void SetData(ChartKind kind, string caption,
			IEnumerable<KeyValuePair<string, double>> data)
		{
			Kind = kind;
			Caption = caption;
			Data = data.ToList();
			Invalidate();
		}

		public void Clear()
		{
			Data = new List<KeyValuePair<string, double>>();
			Caption = "";
			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics g = e.Graphics;
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

			using var titleFont = new Font("Segoe UI", 9.5f, FontStyle.Bold);
			using var labelFont = new Font("Segoe UI", 8f);
			using var inkBrush = new SolidBrush(InkPrimary);
			using var mutedBrush = new SolidBrush(InkMuted);

			if (!string.IsNullOrEmpty(Caption))
				g.DrawString(Caption, titleFont, inkBrush, 10, 8);

			if (Data.Count == 0)
			{
				g.DrawString("No data yet.", labelFont, mutedBrush, 10, 32);
				return;
			}

			Rectangle plot = new Rectangle(10, 30, Width - 20, Height - 42);

			switch (Kind)
			{
				case ChartKind.Pie: DrawPie(g, plot, labelFont, inkBrush, mutedBrush); break;
				case ChartKind.Bar: DrawBars(g, plot, labelFont, inkBrush, mutedBrush); break;
				case ChartKind.Line: DrawLine(g, plot, labelFont, inkBrush, mutedBrush); break;
			}
		}

		private void DrawPie(Graphics g, Rectangle plot, Font font, Brush ink, Brush muted)
		{
			double total = Data.Sum(d => d.Value);
			if (total <= 0) return;

			int size = Math.Min(plot.Height, plot.Width / 2) - 10;
			var circle = new Rectangle(plot.Left + 6, plot.Top + 6, size, size);

			float start = -90f;
			for (int i = 0; i < Data.Count; i++)
			{
				float sweep = (float)(Data[i].Value / total * 360.0);
				using var brush = new SolidBrush(Series[i % Series.Length]);
				g.FillPie(brush, circle, start, sweep);
				// 2px surface gap between neighbouring fills.
				using var gap = new Pen(Surface, 2f);
				g.DrawPie(gap, circle, start, sweep);
				start += sweep;
			}

			// Direct labels to the right: identity never rests on colour alone.
			int ly = plot.Top + 6;
			for (int i = 0; i < Data.Count; i++)
			{
				using var swatch = new SolidBrush(Series[i % Series.Length]);
				g.FillRectangle(swatch, circle.Right + 20, ly + 3, 10, 10);
				double pct = Data[i].Value / total * 100.0;
				g.DrawString($"{Data[i].Key}  —  {Data[i].Value:0} ({pct:0.#}%)",
					font, ink, circle.Right + 36, ly);
				ly += 18;
				if (ly > plot.Bottom - 16) break;
			}
		}

		private void DrawBars(Graphics g, Rectangle plot, Font font, Brush ink, Brush muted)
		{
			double max = Data.Max(d => d.Value);
			if (max <= 0) return;

			float slot = plot.Width / (float)Data.Count;
			float barW = Math.Max(8f, slot - 10f);   // the 2px+ gap between bars

			// Long keys are drawn on a slant, which needs more height underneath
			// than a horizontal label; measure first so nothing is clipped.
			bool slanted;
			using (var probe = new Bitmap(1, 1))
			using (var pg = Graphics.FromImage(probe))
			{
				slanted = Data.Any(d => pg.MeasureString(d.Key, font).Width > slot);
			}
			int labelRoom = slanted ? 56 : 34;
			int baseY = plot.Bottom - labelRoom;
			int usable = baseY - plot.Top - 14;

			using var gridPen = new Pen(Grid, 1f);
			for (int t = 1; t <= 4; t++)
			{
				int y = baseY - (int)(usable * t / 4.0);
				g.DrawLine(gridPen, plot.Left, y, plot.Right, y);
			}
			using var axisPen = new Pen(Grid, 1.5f);
			g.DrawLine(axisPen, plot.Left, baseY, plot.Right, baseY);

			for (int i = 0; i < Data.Count; i++)
			{
				float h = (float)(Data[i].Value / max * usable);
				float x = plot.Left + i * slot + (slot - barW) / 2f;
				var bar = new RectangleF(x, baseY - h, barW, h);

				using var brush = new SolidBrush(Series[i % Series.Length]);
				using var path = RoundedTop(bar, 4f);
				g.FillPath(brush, path);

				string v = Data[i].Value.ToString("0.##");
				SizeF vs = g.MeasureString(v, font);
				g.DrawString(v, font, ink, x + (barW - vs.Width) / 2f, bar.Top - vs.Height - 2);

				string key = Data[i].Key;
				SizeF ks = g.MeasureString(key, font);
				if (ks.Width <= slot)
				{
					g.DrawString(key, font, muted, x + (barW - ks.Width) / 2f, baseY + 4);
				}
				else
				{
					// A slanted label of width W drops W*sin(35) below the axis, so
					// trim it to whatever the reserved room can actually hold.
					string fit = Ellipsize(g, key, font,
						(float)((labelRoom - 10) / Math.Sin(35.0 * Math.PI / 180.0)));
					var state = g.Save();
					g.TranslateTransform(x + barW / 2f, baseY + 6);
					g.RotateTransform(35f);
					g.DrawString(fit, font, muted, 0, 0);
					g.Restore(state);
				}
			}
		}

		private void DrawLine(Graphics g, Rectangle plot, Font font, Brush ink, Brush muted)
		{
			double max = Data.Max(d => d.Value);
			if (max <= 0) return;

			// Inset the x-extent so the first and last marker, and their labels,
			// sit inside the frame instead of straddling it.
			int inset = 26;
			int left = plot.Left + inset;
			int width = plot.Width - inset * 2;
			int baseY = plot.Bottom - 30;
			int usable = baseY - plot.Top - 14;
			float step = Data.Count > 1 ? width / (float)(Data.Count - 1) : 0f;

			using var gridPen = new Pen(Grid, 1f);
			for (int t = 1; t <= 4; t++)
			{
				int y = baseY - (int)(usable * t / 4.0);
				g.DrawLine(gridPen, plot.Left, y, plot.Right, y);
			}
			using var axisPen = new Pen(Grid, 1.5f);
			g.DrawLine(axisPen, plot.Left, baseY, plot.Right, baseY);

			var pts = new PointF[Data.Count];
			for (int i = 0; i < Data.Count; i++)
			{
				float x = Data.Count > 1 ? left + i * step : left + width / 2f;
				float y = baseY - (float)(Data[i].Value / max * usable);
				pts[i] = new PointF(x, y);
			}

			using var linePen = new Pen(Series[0], 2f) { LineJoin = LineJoin.Round };
			if (pts.Length > 1) g.DrawLines(linePen, pts);

			foreach (var (p, i) in pts.Select((p, i) => (p, i)))
			{
				// 2px surface ring so overlapping marks stay separable.
				using var ring = new SolidBrush(Surface);
				g.FillEllipse(ring, p.X - 6, p.Y - 6, 12, 12);
				using var dot = new SolidBrush(Series[0]);
				g.FillEllipse(dot, p.X - 4, p.Y - 4, 8, 8);

				string v = Data[i].Value.ToString("0.##");
				SizeF vs = g.MeasureString(v, font);
				g.DrawString(v, font, ink, p.X - vs.Width / 2f, p.Y - vs.Height - 8);

				string key = Data[i].Key;
				SizeF ks = g.MeasureString(key, font);
				g.DrawString(key, font, muted, p.X - ks.Width / 2f, baseY + 4);
			}
		}

		private static string Ellipsize(Graphics g, string text, Font font, float maxWidth)
		{
			if (g.MeasureString(text, font).Width <= maxWidth) return text;
			for (int n = text.Length - 1; n > 1; n--)
			{
				string candidate = text.Substring(0, n) + "…";
				if (g.MeasureString(candidate, font).Width <= maxWidth) return candidate;
			}
			return text.Substring(0, 1) + "…";
		}

		private static GraphicsPath RoundedTop(RectangleF r, float radius)
		{
			var path = new GraphicsPath();
			if (r.Height <= radius * 2 || r.Width <= radius * 2)
			{
				path.AddRectangle(r);
				return path;
			}
			float d = radius * 2;
			path.AddArc(r.Left, r.Top, d, d, 180, 90);
			path.AddArc(r.Right - d, r.Top, d, d, 270, 90);
			path.AddLine(r.Right, r.Top + radius, r.Right, r.Bottom);
			path.AddLine(r.Right, r.Bottom, r.Left, r.Bottom);
			path.CloseFigure();
			return path;
		}
	}
}
