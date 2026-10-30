namespace lab9
{
	partial class Form1
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.lblTitle = new System.Windows.Forms.Label();
			this.lblSearchPrompt = new System.Windows.Forms.Label();
			this.txtSearchTitle = new System.Windows.Forms.TextBox();
			this.btnSearchBooks = new System.Windows.Forms.Button();
			this.btnShowYearTrends = new System.Windows.Forms.Button();
			this.btnShowAuthors = new System.Windows.Forms.Button();
			this.btnShowRatings = new System.Windows.Forms.Button();
			this.chartCategories = new lab9.ChartPanel();
			this.chartTrends = new lab9.ChartPanel();
			this.lblStatus = new System.Windows.Forms.Label();
			this.SuspendLayout();
			//
			// lblTitle
			//
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.lblTitle.Location = new System.Drawing.Point(22, 16);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Text = "Data Mining from the Google Books API";
			//
			// lblSearchPrompt
			//
			this.lblSearchPrompt.AutoSize = true;
			this.lblSearchPrompt.Location = new System.Drawing.Point(22, 56);
			this.lblSearchPrompt.Name = "lblSearchPrompt";
			this.lblSearchPrompt.Text = "Search query:";
			//
			// txtSearchTitle
			//
			this.txtSearchTitle.Location = new System.Drawing.Point(115, 53);
			this.txtSearchTitle.Name = "txtSearchTitle";
			this.txtSearchTitle.Size = new System.Drawing.Size(200, 23);
			//
			// btnSearchBooks
			//
			this.btnSearchBooks.Location = new System.Drawing.Point(327, 52);
			this.btnSearchBooks.Name = "btnSearchBooks";
			this.btnSearchBooks.Size = new System.Drawing.Size(150, 26);
			this.btnSearchBooks.Text = "Search and Mine";
			this.btnSearchBooks.UseVisualStyleBackColor = true;
			this.btnSearchBooks.Click += new System.EventHandler(this.btnSearchBooks_Click);
			//
			// btnShowYearTrends
			//
			this.btnShowYearTrends.Location = new System.Drawing.Point(489, 52);
			this.btnShowYearTrends.Name = "btnShowYearTrends";
			this.btnShowYearTrends.Size = new System.Drawing.Size(120, 26);
			this.btnShowYearTrends.Text = "Year Trends";
			this.btnShowYearTrends.UseVisualStyleBackColor = true;
			this.btnShowYearTrends.Click += new System.EventHandler(this.btnShowYearTrends_Click);
			//
			// btnShowAuthors
			//
			this.btnShowAuthors.Location = new System.Drawing.Point(619, 52);
			this.btnShowAuthors.Name = "btnShowAuthors";
			this.btnShowAuthors.Size = new System.Drawing.Size(120, 26);
			this.btnShowAuthors.Text = "Top Authors";
			this.btnShowAuthors.UseVisualStyleBackColor = true;
			this.btnShowAuthors.Click += new System.EventHandler(this.btnShowAuthors_Click);
			//
			// btnShowRatings
			//
			this.btnShowRatings.Location = new System.Drawing.Point(749, 52);
			this.btnShowRatings.Name = "btnShowRatings";
			this.btnShowRatings.Size = new System.Drawing.Size(120, 26);
			this.btnShowRatings.Text = "Ratings";
			this.btnShowRatings.UseVisualStyleBackColor = true;
			this.btnShowRatings.Click += new System.EventHandler(this.btnShowRatings_Click);
			//
			// chartCategories
			//
			this.chartCategories.Location = new System.Drawing.Point(22, 92);
			this.chartCategories.Name = "chartCategories";
			this.chartCategories.Size = new System.Drawing.Size(847, 215);
			//
			// chartTrends
			//
			this.chartTrends.Location = new System.Drawing.Point(22, 317);
			this.chartTrends.Name = "chartTrends";
			this.chartTrends.Size = new System.Drawing.Size(847, 235);
			//
			// lblStatus
			//
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(22, 562);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Text = "Ready.";
			//
			// Form1
			//
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(892, 592);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.chartTrends);
			this.Controls.Add(this.chartCategories);
			this.Controls.Add(this.btnShowRatings);
			this.Controls.Add(this.btnShowAuthors);
			this.Controls.Add(this.btnShowYearTrends);
			this.Controls.Add(this.btnSearchBooks);
			this.Controls.Add(this.txtSearchTitle);
			this.Controls.Add(this.lblSearchPrompt);
			this.Controls.Add(this.lblTitle);
			this.Name = "Form1";
			this.Text = "Lab 9 - Data Mining and Visualization";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblSearchPrompt;
		private System.Windows.Forms.TextBox txtSearchTitle;
		private System.Windows.Forms.Button btnSearchBooks;
		private System.Windows.Forms.Button btnShowYearTrends;
		private System.Windows.Forms.Button btnShowAuthors;
		private System.Windows.Forms.Button btnShowRatings;
		private lab9.ChartPanel chartCategories;
		private lab9.ChartPanel chartTrends;
		private System.Windows.Forms.Label lblStatus;
	}
}
