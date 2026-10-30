namespace lab3
{
	// Base class. GetInfo is virtual so every subclass can describe itself
	// in its own way while callers keep treating it as a Book.
	public class Book
	{
		public string Title { get; set; } = "";
		public string Author { get; set; } = "";

		public virtual string GetInfo()
		{
			return $"{Title} by {Author}";
		}
	}

	public class Magazine : Book
	{
		public int IssueNumber { get; set; }

		public override string GetInfo()
		{
			return $"{Title} - Issue {IssueNumber}";
		}
	}

	public class Ebook : Book
	{
		public int FileSizeMB { get; set; }

		public override string GetInfo()
		{
			return $"{Title} (Ebook, {FileSizeMB}MB)";
		}
	}

	// Task 3: two more subclasses, added without touching Book or the
	// method that displays them.
	public class Textbook : Book
	{
		public string Subject { get; set; } = "";

		public override string GetInfo()
		{
			return $"{Title} by {Author} (Textbook, {Subject})";
		}
	}

	public class AudioBook : Book
	{
		public int Duration { get; set; }
		public string Narrator { get; set; } = "";

		public override string GetInfo()
		{
			return $"{Title} (Audiobook, {Duration} min, read by {Narrator})";
		}
	}

	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		// Task 1: one object, described through the base class reference.
		private void btnShowInfo_Click(object sender, EventArgs e)
		{
			Book myBook = new Magazine
			{
				Title = "Tech Weekly",
				Author = "Jane Doe",
				IssueNumber = 12
			};
			MessageBox.Show(myBook.GetInfo());
		}

		// Task 2: the array is of Book, but each element answers GetInfo with
		// its own override. The loop never asks what type anything is.
		private void DisplayBooks(Book[] books)
		{
			listBoxBooks.Items.Clear();
			foreach (Book book in books)
			{
				listBoxBooks.Items.Add(book.GetInfo());
			}
		}

		private void btnShowAll_Click(object sender, EventArgs e)
		{
			Book[] books = new Book[]
			{
				new Book { Title = "Generic Book", Author = "John Smith" },
				new Magazine { Title = "Tech Weekly", Author = "Jane Doe", IssueNumber = 12 },
				new Ebook { Title = "Learn C#", Author = "Mark Jones", FileSizeMB = 5 },
				new Textbook { Title = "Software Design", Author = "A. Writer", Subject = "Engineering" },
				new AudioBook { Title = "Clean Code", Duration = 420, Narrator = "R. Reader" }
			};

			DisplayBooks(books);
		}
	}
}
