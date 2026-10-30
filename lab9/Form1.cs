using System.Net.Http;

namespace lab9
{
	public partial class Form1 : Form
	{
		// The mined result set every visualisation is computed from.
		private List<BookResult> books = new List<BookResult>();
		private string sourceUsed = "";

		public Form1()
		{
			InitializeComponent();
			Load += Form1_Load;
		}

		// Mine a default query on startup so the charts are populated as soon as
		// the window opens; the query box and buttons still work as normal.
		private async void Form1_Load(object? sender, EventArgs e)
		{
			txtSearchTitle.Text = "clean code";
			SetBusy(true, "Mining the Google Books API...");
			try
			{
				books = await MineAsync(txtSearchTitle.Text);
				lblStatus.Text = $"{books.Count} book(s) mined from {sourceUsed}.";
				ShowCategories();
				ShowYearTrends();
			}
			catch (Exception ex)
			{
				lblStatus.Text = $"Mining failed: {ex.Message}";
			}
			finally
			{
				SetBusy(false, null);
			}
		}

		// Task 1 Step 2. Fetch the raw data once, then mine it four ways.
		private async void btnSearchBooks_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtSearchTitle.Text))
			{
				lblStatus.Text = "Enter a search query first.";
				return;
			}

			SetBusy(true, "Mining the Google Books API...");

			try
			{
				books = await MineAsync(txtSearchTitle.Text.Trim());
				lblStatus.Text = $"{books.Count} book(s) mined from {sourceUsed}.";
				ShowCategories();
				ShowYearTrends();
			}
			catch (Exception ex)
			{
				lblStatus.Text = $"Mining failed: {ex.Message}";
			}
			finally
			{
				SetBusy(false, null);
			}
		}

		private async Task<List<BookResult>> MineAsync(string query)
		{
			var all = new List<BookResult>();

			// Two pages of 40 gives enough rows for the distributions to mean
			// something rather than being three bars wide.
			try
			{
				for (int page = 0; page < 2; page++)
				{
					all.AddRange(await BooksApi.SearchByAuthorAsync(query, page * 40, 40));
				}
				sourceUsed = BooksApi.GoogleBooks;
			}
			catch (HttpRequestException ex)
			{
				lblStatus.Text = $"{BooksApi.GoogleBooks} returned {(int?)ex.StatusCode}; using the fallback.";
				all.Clear();
				for (int page = 1; page <= 2; page++)
				{
					all.AddRange(await BooksApi.SearchOpenLibraryAsync(query, page, 50));
				}
				sourceUsed = BooksApi.OpenLibrary;
			}

			return all;
		}

		// Task 1 Step 3 and 4. Count how often each category appears, then show
		// the distribution as a pie chart.
		private void ShowCategories()
		{
			var counts = books
				.SelectMany(b => b.Categories.Split(',', StringSplitOptions.RemoveEmptyEntries))
				.Select(c => c.Trim())
				.Where(c => c.Length > 0)
				.GroupBy(c => c, StringComparer.OrdinalIgnoreCase)
				.OrderByDescending(gr => gr.Count())
				.Take(6)
				.Select(gr => new KeyValuePair<string, double>(Shorten(gr.Key), gr.Count()))
				.ToList();

			if (counts.Count == 0)
			{
				chartCategories.SetData(ChartKind.Pie, "Categories — none reported", counts);
				return;
			}

			chartCategories.SetData(ChartKind.Pie,
				$"Top book categories ({sourceUsed})", counts);
		}

		// Task 2. Publication years as a bar chart.
		private void ShowYearTrends()
		{
			var counts = books
				.Select(b => b.PublishedDate)
				.Where(d => d.Length >= 4 && int.TryParse(d.Substring(0, 4), out _))
				.Select(d => int.Parse(d.Substring(0, 4)))
				.Where(y => y > 1900 && y <= DateTime.Now.Year)
				.GroupBy(y => y)
				.OrderBy(gr => gr.Key)
				.Select(gr => new KeyValuePair<string, double>(gr.Key.ToString(), gr.Count()))
				.ToList();

			// Too many years makes an unreadable forest of bars; keep the busiest.
			if (counts.Count > 14)
			{
				counts = counts.OrderByDescending(c => c.Value).Take(14)
					.OrderBy(c => int.Parse(c.Key)).ToList();
			}

			chartTrends.SetData(ChartKind.Bar,
				$"Books per publication year ({sourceUsed})", counts);
		}

		private void btnShowYearTrends_Click(object sender, EventArgs e)
		{
			if (!HasData()) return;
			ShowYearTrends();
		}

		// Task 3 part 1. Most frequent authors, as a bar chart.
		private void btnShowAuthors_Click(object sender, EventArgs e)
		{
			if (!HasData()) return;

			var counts = books
				.SelectMany(b => b.Authors.Split(',', StringSplitOptions.RemoveEmptyEntries))
				.Select(a => a.Trim())
				.Where(a => a.Length > 0)
				.GroupBy(a => a, StringComparer.OrdinalIgnoreCase)
				.OrderByDescending(gr => gr.Count())
				.Take(8)
				.Select(gr => new KeyValuePair<string, double>(Shorten(gr.Key), gr.Count()))
				.ToList();

			chartTrends.SetData(ChartKind.Bar,
				$"Most frequent authors ({sourceUsed})", counts);
			lblStatus.Text = $"{counts.Count} author(s) charted.";
		}

		// Task 3 part 2. Ratings distribution, as a line chart.
		private void btnShowRatings_Click(object sender, EventArgs e)
		{
			if (!HasData()) return;

			var buckets = new[] { "1–2", "2–3", "3–4", "4–5" };
			var tally = new int[buckets.Length];
			int rated = 0;

			foreach (BookResult b in books)
			{
				if (b.Rating is not double r) continue;
				rated++;
				int i = r < 2 ? 0 : r < 3 ? 1 : r < 4 ? 2 : 3;
				tally[i]++;
			}

			var data = buckets
				.Select((label, i) => new KeyValuePair<string, double>(label, tally[i]))
				.ToList();

			chartTrends.SetData(ChartKind.Line,
				$"Rating distribution — {rated} of {books.Count} books rated ({sourceUsed})",
				data);
			lblStatus.Text = rated == 0
				? "No ratings were reported for these books."
				: $"{rated} rated book(s) charted.";
		}

		private bool HasData()
		{
			if (books.Count > 0) return true;
			lblStatus.Text = "Search for books first.";
			return false;
		}

		private static string Shorten(string s) =>
			s.Length <= 18 ? s : s.Substring(0, 17) + "…";

		private void SetBusy(bool busy, string? message)
		{
			btnSearchBooks.Enabled = !busy;
			btnShowYearTrends.Enabled = !busy;
			btnShowAuthors.Enabled = !busy;
			btnShowRatings.Enabled = !busy;
			if (busy && message != null) lblStatus.Text = message;
		}
	}
}
