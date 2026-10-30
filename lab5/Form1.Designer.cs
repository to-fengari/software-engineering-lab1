namespace lab5
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
			this.lblBookIDPrompt = new System.Windows.Forms.Label();
			this.txtBookID = new System.Windows.Forms.TextBox();
			this.btnAddBook = new System.Windows.Forms.Button();
			this.btnShowBooks = new System.Windows.Forms.Button();
			this.btnUpdateBook = new System.Windows.Forms.Button();
			this.btnDeleteBook = new System.Windows.Forms.Button();
			this.lblSearchPrompt = new System.Windows.Forms.Label();
			this.txtSearchAuthor = new System.Windows.Forms.TextBox();
			this.btnSearchByAuthor = new System.Windows.Forms.Button();
			this.listBoxBooks = new System.Windows.Forms.ListBox();
			this.lblStatus = new System.Windows.Forms.Label();
			this.SuspendLayout();
			//
			// lblTitle
			//
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.lblTitle.Location = new System.Drawing.Point(30, 20);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Text = "Bookstore Database";
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
			// lblBookIDPrompt
			//
			this.lblBookIDPrompt.AutoSize = true;
			this.lblBookIDPrompt.Location = new System.Drawing.Point(30, 132);
			this.lblBookIDPrompt.Name = "lblBookIDPrompt";
			this.lblBookIDPrompt.Text = "BookID:";
			//
			// txtBookID
			//
			this.txtBookID.Location = new System.Drawing.Point(125, 129);
			this.txtBookID.Name = "txtBookID";
			this.txtBookID.Size = new System.Drawing.Size(80, 23);
			//
			// btnAddBook
			//
			this.btnAddBook.Location = new System.Drawing.Point(30, 175);
			this.btnAddBook.Name = "btnAddBook";
			this.btnAddBook.Size = new System.Drawing.Size(130, 28);
			this.btnAddBook.Text = "Add Book";
			this.btnAddBook.UseVisualStyleBackColor = true;
			this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
			//
			// btnShowBooks
			//
			this.btnShowBooks.Location = new System.Drawing.Point(175, 175);
			this.btnShowBooks.Name = "btnShowBooks";
			this.btnShowBooks.Size = new System.Drawing.Size(130, 28);
			this.btnShowBooks.Text = "Show Books";
			this.btnShowBooks.UseVisualStyleBackColor = true;
			this.btnShowBooks.Click += new System.EventHandler(this.btnShowBooks_Click);
			//
			// btnUpdateBook
			//
			this.btnUpdateBook.Location = new System.Drawing.Point(30, 213);
			this.btnUpdateBook.Name = "btnUpdateBook";
			this.btnUpdateBook.Size = new System.Drawing.Size(130, 28);
			this.btnUpdateBook.Text = "Update Book";
			this.btnUpdateBook.UseVisualStyleBackColor = true;
			this.btnUpdateBook.Click += new System.EventHandler(this.btnUpdateBook_Click);
			//
			// btnDeleteBook
			//
			this.btnDeleteBook.Location = new System.Drawing.Point(175, 213);
			this.btnDeleteBook.Name = "btnDeleteBook";
			this.btnDeleteBook.Size = new System.Drawing.Size(130, 28);
			this.btnDeleteBook.Text = "Delete Book";
			this.btnDeleteBook.UseVisualStyleBackColor = true;
			this.btnDeleteBook.Click += new System.EventHandler(this.btnDeleteBook_Click);
			//
			// lblSearchPrompt
			//
			this.lblSearchPrompt.AutoSize = true;
			this.lblSearchPrompt.Location = new System.Drawing.Point(30, 266);
			this.lblSearchPrompt.Name = "lblSearchPrompt";
			this.lblSearchPrompt.Text = "Search author:";
			//
			// txtSearchAuthor
			//
			this.txtSearchAuthor.Location = new System.Drawing.Point(125, 263);
			this.txtSearchAuthor.Name = "txtSearchAuthor";
			this.txtSearchAuthor.Size = new System.Drawing.Size(180, 23);
			//
			// btnSearchByAuthor
			//
			this.btnSearchByAuthor.Location = new System.Drawing.Point(30, 298);
			this.btnSearchByAuthor.Name = "btnSearchByAuthor";
			this.btnSearchByAuthor.Size = new System.Drawing.Size(275, 28);
			this.btnSearchByAuthor.Text = "Search Books by Author";
			this.btnSearchByAuthor.UseVisualStyleBackColor = true;
			this.btnSearchByAuthor.Click += new System.EventHandler(this.btnSearchByAuthor_Click);
			//
			// listBoxBooks
			//
			this.listBoxBooks.FormattingEnabled = true;
			this.listBoxBooks.ItemHeight = 15;
			this.listBoxBooks.Location = new System.Drawing.Point(345, 61);
			this.listBoxBooks.Name = "listBoxBooks";
			this.listBoxBooks.Size = new System.Drawing.Size(420, 265);
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
			this.ClientSize = new System.Drawing.Size(800, 390);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.listBoxBooks);
			this.Controls.Add(this.btnSearchByAuthor);
			this.Controls.Add(this.txtSearchAuthor);
			this.Controls.Add(this.lblSearchPrompt);
			this.Controls.Add(this.btnDeleteBook);
			this.Controls.Add(this.btnUpdateBook);
			this.Controls.Add(this.btnShowBooks);
			this.Controls.Add(this.btnAddBook);
			this.Controls.Add(this.txtBookID);
			this.Controls.Add(this.lblBookIDPrompt);
			this.Controls.Add(this.txtBookTitle);
			this.Controls.Add(this.lblBookPrompt);
			this.Controls.Add(this.txtAuthorName);
			this.Controls.Add(this.lblAuthorPrompt);
			this.Controls.Add(this.lblTitle);
			this.Name = "Form1";
			this.Text = "Lab 5 - Bookstore Database";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblAuthorPrompt;
		private System.Windows.Forms.TextBox txtAuthorName;
		private System.Windows.Forms.Label lblBookPrompt;
		private System.Windows.Forms.TextBox txtBookTitle;
		private System.Windows.Forms.Label lblBookIDPrompt;
		private System.Windows.Forms.TextBox txtBookID;
		private System.Windows.Forms.Button btnAddBook;
		private System.Windows.Forms.Button btnShowBooks;
		private System.Windows.Forms.Button btnUpdateBook;
		private System.Windows.Forms.Button btnDeleteBook;
		private System.Windows.Forms.Label lblSearchPrompt;
		private System.Windows.Forms.TextBox txtSearchAuthor;
		private System.Windows.Forms.Button btnSearchByAuthor;
		private System.Windows.Forms.ListBox listBoxBooks;
		private System.Windows.Forms.Label lblStatus;
	}
}
