namespace lab3
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
			this.btnShowInfo = new System.Windows.Forms.Button();
			this.btnShowAll = new System.Windows.Forms.Button();
			this.listBoxBooks = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			//
			// lblTitle
			//
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.lblTitle.Location = new System.Drawing.Point(40, 25);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Bookstore System";
			//
			// btnShowInfo
			//
			this.btnShowInfo.Location = new System.Drawing.Point(40, 70);
			this.btnShowInfo.Name = "btnShowInfo";
			this.btnShowInfo.Size = new System.Drawing.Size(200, 30);
			this.btnShowInfo.TabIndex = 1;
			this.btnShowInfo.Text = "Show One Book";
			this.btnShowInfo.UseVisualStyleBackColor = true;
			this.btnShowInfo.Click += new System.EventHandler(this.btnShowInfo_Click);
			//
			// btnShowAll
			//
			this.btnShowAll.Location = new System.Drawing.Point(40, 112);
			this.btnShowAll.Name = "btnShowAll";
			this.btnShowAll.Size = new System.Drawing.Size(200, 30);
			this.btnShowAll.TabIndex = 2;
			this.btnShowAll.Text = "Show All Books";
			this.btnShowAll.UseVisualStyleBackColor = true;
			this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
			//
			// listBoxBooks
			//
			this.listBoxBooks.FormattingEnabled = true;
			this.listBoxBooks.ItemHeight = 15;
			this.listBoxBooks.Location = new System.Drawing.Point(280, 70);
			this.listBoxBooks.Name = "listBoxBooks";
			this.listBoxBooks.Size = new System.Drawing.Size(460, 244);
			this.listBoxBooks.TabIndex = 3;
			//
			// Form1
			//
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 380);
			this.Controls.Add(this.listBoxBooks);
			this.Controls.Add(this.btnShowAll);
			this.Controls.Add(this.btnShowInfo);
			this.Controls.Add(this.lblTitle);
			this.Name = "Form1";
			this.Text = "Lab 3 - Object-Oriented Design";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Button btnShowInfo;
		private System.Windows.Forms.Button btnShowAll;
		private System.Windows.Forms.ListBox listBoxBooks;
	}
}
