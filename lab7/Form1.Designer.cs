namespace lab7
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
			this.lblAuthorPrompt = new System.Windows.Forms.Label();
			this.txtAuthorName = new System.Windows.Forms.TextBox();
			this.lblBookPrompt = new System.Windows.Forms.Label();
			this.txtBookTitle = new System.Windows.Forms.TextBox();
			this.btnAddBook = new System.Windows.Forms.Button();
			this.lblSearchPrompt = new System.Windows.Forms.Label();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.btnExportBooks = new System.Windows.Forms.Button();
			this.btnImportBooks = new System.Windows.Forms.Button();
			this.listBoxBooks = new System.Windows.Forms.ListBox();
			this.lblPageNumber = new System.Windows.Forms.Label();
			this.btnPreviousPage = new System.Windows.Forms.Button();
			this.btnNextPage = new System.Windows.Forms.Button();
			this.lblStatus = new System.Windows.Forms.Label();
			this.SuspendLayout();
			//
			// lblTitle
			//
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.lblTitle.Location = new System.Drawing.Point(30, 20);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Text = "Paged Bookstore";
			//
			// lblAuthorPrompt
			//
			this.lblAuthorPrompt.AutoSize = true;
			this.lblAuthorPrompt.Location = new System.Drawing.Point(30, 64);
			this.lblAuthorPrompt.Name = "lblAuthorPrompt";
			this.lblAuthorPrompt.Text = "Author name:";
			//
			// txtAuthorName
			//
			this.txtAuthorName.Location = new System.Drawing.Point(125, 61);
			this.txtAuthorName.Name = "txtAuthorName";
			this.txtAuthorName.Size = new System.Drawing.Size(180, 23);
			//
			// lblBookPrompt
			//
			this.lblBookPrompt.AutoSize = true;
			this.lblBookPrompt.Location = new System.Drawing.Point(30, 98);
			this.lblBookPrompt.Name = "lblBookPrompt";
			this.lblBookPrompt.Text = "Book title:";
			//
			// txtBookTitle
			//
			this.txtBookTitle.Location = new System.Drawing.Point(125, 95);
			this.txtBookTitle.Name = "txtBookTitle";
			this.txtBookTitle.Size = new System.Drawing.Size(180, 23);
			//
			// btnAddBook
			//
			this.btnAddBook.Location = new System.Drawing.Point(30, 130);
			this.btnAddBook.Name = "btnAddBook";
			this.btnAddBook.Size = new System.Drawing.Size(275, 28);
			this.btnAddBook.Text = "Add Book (async, with error handling)";
			this.btnAddBook.UseVisualStyleBackColor = true;
			this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
			//
			// lblSearchPrompt
			//
			this.lblSearchPrompt.AutoSize = true;
			this.lblSearchPrompt.Location = new System.Drawing.Point(30, 182);
			this.lblSearchPrompt.Name = "lblSearchPrompt";
			this.lblSearchPrompt.Text = "Search title:";
			//
			// txtSearch
			//
			this.txtSearch.Location = new System.Drawing.Point(125, 179);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(180, 23);
			//
			// btnSearch
			//
			this.btnSearch.Location = new System.Drawing.Point(30, 212);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(275, 28);
			this.btnSearch.Text = "Search (async)";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			//
			// btnExportBooks
			//
			this.btnExportBooks.Location = new System.Drawing.Point(30, 264);
			this.btnExportBooks.Name = "btnExportBooks";
			this.btnExportBooks.Size = new System.Drawing.Size(130, 28);
			this.btnExportBooks.Text = "Export to File";
			this.btnExportBooks.UseVisualStyleBackColor = true;
			this.btnExportBooks.Click += new System.EventHandler(this.btnExportBooks_Click);
			//
			// btnImportBooks
			//
			this.btnImportBooks.Location = new System.Drawing.Point(175, 264);
			this.btnImportBooks.Name = "btnImportBooks";
			this.btnImportBooks.Size = new System.Drawing.Size(130, 28);
			this.btnImportBooks.Text = "Import from File";
			this.btnImportBooks.UseVisualStyleBackColor = true;
			this.btnImportBooks.Click += new System.EventHandler(this.btnImportBooks_Click);
			//
			// listBoxBooks
			//
			this.listBoxBooks.FormattingEnabled = true;
			this.listBoxBooks.ItemHeight = 15;
			this.listBoxBooks.Location = new System.Drawing.Point(345, 61);
			this.listBoxBooks.Name = "listBoxBooks";
			this.listBoxBooks.Size = new System.Drawing.Size(420, 199);
			//
			// lblPageNumber
			//
			this.lblPageNumber.AutoSize = true;
			this.lblPageNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.lblPageNumber.Location = new System.Drawing.Point(345, 272);
			this.lblPageNumber.Name = "lblPageNumber";
			this.lblPageNumber.Text = "Page 1 of 1";
			//
			// btnPreviousPage
			//
			this.btnPreviousPage.Location = new System.Drawing.Point(345, 298);
			this.btnPreviousPage.Name = "btnPreviousPage";
			this.btnPreviousPage.Size = new System.Drawing.Size(130, 28);
			this.btnPreviousPage.Text = "Previous Page";
			this.btnPreviousPage.UseVisualStyleBackColor = true;
			this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
			//
			// btnNextPage
			//
			this.btnNextPage.Location = new System.Drawing.Point(490, 298);
			this.btnNextPage.Name = "btnNextPage";
			this.btnNextPage.Size = new System.Drawing.Size(130, 28);
			this.btnNextPage.Text = "Next Page";
			this.btnNextPage.UseVisualStyleBackColor = true;
			this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
			//
			// lblStatus
			//
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(30, 345);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Text = "Ready.";
			//
			// Form1
			//
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 385);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.btnNextPage);
			this.Controls.Add(this.btnPreviousPage);
			this.Controls.Add(this.lblPageNumber);
			this.Controls.Add(this.listBoxBooks);
			this.Controls.Add(this.btnImportBooks);
			this.Controls.Add(this.btnExportBooks);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.lblSearchPrompt);
			this.Controls.Add(this.btnAddBook);
			this.Controls.Add(this.txtBookTitle);
			this.Controls.Add(this.lblBookPrompt);
			this.Controls.Add(this.txtAuthorName);
			this.Controls.Add(this.lblAuthorPrompt);
			this.Controls.Add(this.lblTitle);
			this.Name = "Form1";
			this.Text = "Lab 7 - Advanced Asynchronous Functionality";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblAuthorPrompt;
		private System.Windows.Forms.TextBox txtAuthorName;
		private System.Windows.Forms.Label lblBookPrompt;
		private System.Windows.Forms.TextBox txtBookTitle;
		private System.Windows.Forms.Button btnAddBook;
		private System.Windows.Forms.Label lblSearchPrompt;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Button btnExportBooks;
		private System.Windows.Forms.Button btnImportBooks;
		private System.Windows.Forms.ListBox listBoxBooks;
		private System.Windows.Forms.Label lblPageNumber;
		private System.Windows.Forms.Button btnPreviousPage;
		private System.Windows.Forms.Button btnNextPage;
		private System.Windows.Forms.Label lblStatus;
	}
}
