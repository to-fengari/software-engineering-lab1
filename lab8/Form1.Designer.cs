namespace lab8
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
			this.lblISBNPrompt = new System.Windows.Forms.Label();
			this.txtISBN = new System.Windows.Forms.TextBox();
			this.btnFetchBook = new System.Windows.Forms.Button();
			this.txtBookDetails = new System.Windows.Forms.TextBox();
			this.lblAuthorPrompt = new System.Windows.Forms.Label();
			this.txtAuthor = new System.Windows.Forms.TextBox();
			this.btnSearchAuthor = new System.Windows.Forms.Button();
			this.listBoxResults = new System.Windows.Forms.ListBox();
			this.lblPage = new System.Windows.Forms.Label();
			this.btnPreviousPage = new System.Windows.Forms.Button();
			this.btnNextPage = new System.Windows.Forms.Button();
			this.lblStatus = new System.Windows.Forms.Label();
			this.SuspendLayout();
			//
			// lblTitle
			//
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.lblTitle.Location = new System.Drawing.Point(25, 18);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Text = "Google Books API";
			//
			// lblISBNPrompt
			//
			this.lblISBNPrompt.AutoSize = true;
			this.lblISBNPrompt.Location = new System.Drawing.Point(25, 58);
			this.lblISBNPrompt.Name = "lblISBNPrompt";
			this.lblISBNPrompt.Text = "ISBN:";
			//
			// txtISBN
			//
			this.txtISBN.Location = new System.Drawing.Point(90, 55);
			this.txtISBN.Name = "txtISBN";
			this.txtISBN.Size = new System.Drawing.Size(180, 23);
			//
			// btnFetchBook
			//
			this.btnFetchBook.Location = new System.Drawing.Point(25, 88);
			this.btnFetchBook.Name = "btnFetchBook";
			this.btnFetchBook.Size = new System.Drawing.Size(245, 28);
			this.btnFetchBook.Text = "Fetch Book by ISBN";
			this.btnFetchBook.UseVisualStyleBackColor = true;
			this.btnFetchBook.Click += new System.EventHandler(this.btnFetchBook_Click);
			//
			// txtBookDetails
			//
			this.txtBookDetails.Location = new System.Drawing.Point(25, 126);
			this.txtBookDetails.Multiline = true;
			this.txtBookDetails.Name = "txtBookDetails";
			this.txtBookDetails.ReadOnly = true;
			this.txtBookDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtBookDetails.Size = new System.Drawing.Size(360, 235);
			//
			// lblAuthorPrompt
			//
			this.lblAuthorPrompt.AutoSize = true;
			this.lblAuthorPrompt.Location = new System.Drawing.Point(415, 58);
			this.lblAuthorPrompt.Name = "lblAuthorPrompt";
			this.lblAuthorPrompt.Text = "Author:";
			//
			// txtAuthor
			//
			this.txtAuthor.Location = new System.Drawing.Point(475, 55);
			this.txtAuthor.Name = "txtAuthor";
			this.txtAuthor.Size = new System.Drawing.Size(180, 23);
			//
			// btnSearchAuthor
			//
			this.btnSearchAuthor.Location = new System.Drawing.Point(415, 88);
			this.btnSearchAuthor.Name = "btnSearchAuthor";
			this.btnSearchAuthor.Size = new System.Drawing.Size(345, 28);
			this.btnSearchAuthor.Text = "Search Books by Author";
			this.btnSearchAuthor.UseVisualStyleBackColor = true;
			this.btnSearchAuthor.Click += new System.EventHandler(this.btnSearchAuthor_Click);
			//
			// listBoxResults
			//
			this.listBoxResults.FormattingEnabled = true;
			this.listBoxResults.ItemHeight = 15;
			this.listBoxResults.Location = new System.Drawing.Point(415, 126);
			this.listBoxResults.Name = "listBoxResults";
			this.listBoxResults.Size = new System.Drawing.Size(345, 199);
			//
			// lblPage
			//
			this.lblPage.AutoSize = true;
			this.lblPage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.lblPage.Location = new System.Drawing.Point(415, 334);
			this.lblPage.Name = "lblPage";
			this.lblPage.Text = "Page 1";
			//
			// btnPreviousPage
			//
			this.btnPreviousPage.Enabled = false;
			this.btnPreviousPage.Location = new System.Drawing.Point(415, 358);
			this.btnPreviousPage.Name = "btnPreviousPage";
			this.btnPreviousPage.Size = new System.Drawing.Size(110, 26);
			this.btnPreviousPage.Text = "Previous";
			this.btnPreviousPage.UseVisualStyleBackColor = true;
			this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
			//
			// btnNextPage
			//
			this.btnNextPage.Enabled = false;
			this.btnNextPage.Location = new System.Drawing.Point(535, 358);
			this.btnNextPage.Name = "btnNextPage";
			this.btnNextPage.Size = new System.Drawing.Size(110, 26);
			this.btnNextPage.Text = "Next";
			this.btnNextPage.UseVisualStyleBackColor = true;
			this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
			//
			// lblStatus
			//
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(25, 398);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Text = "Ready.";
			//
			// Form1
			//
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 432);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.btnNextPage);
			this.Controls.Add(this.btnPreviousPage);
			this.Controls.Add(this.lblPage);
			this.Controls.Add(this.listBoxResults);
			this.Controls.Add(this.btnSearchAuthor);
			this.Controls.Add(this.txtAuthor);
			this.Controls.Add(this.lblAuthorPrompt);
			this.Controls.Add(this.txtBookDetails);
			this.Controls.Add(this.btnFetchBook);
			this.Controls.Add(this.txtISBN);
			this.Controls.Add(this.lblISBNPrompt);
			this.Controls.Add(this.lblTitle);
			this.Name = "Form1";
			this.Text = "Lab 8 - API Integration";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblISBNPrompt;
		private System.Windows.Forms.TextBox txtISBN;
		private System.Windows.Forms.Button btnFetchBook;
		private System.Windows.Forms.TextBox txtBookDetails;
		private System.Windows.Forms.Label lblAuthorPrompt;
		private System.Windows.Forms.TextBox txtAuthor;
		private System.Windows.Forms.Button btnSearchAuthor;
		private System.Windows.Forms.ListBox listBoxResults;
		private System.Windows.Forms.Label lblPage;
		private System.Windows.Forms.Button btnPreviousPage;
		private System.Windows.Forms.Button btnNextPage;
		private System.Windows.Forms.Label lblStatus;
	}
}
