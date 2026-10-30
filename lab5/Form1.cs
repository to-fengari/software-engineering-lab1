using Microsoft.EntityFrameworkCore;

namespace lab5
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		// Task 5. Create: add an author and a book in one go. The book is
		// attached to the author through the navigation property, so EF works
		// out the AuthorID itself.
		private void btnAddBook_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtAuthorName.Text) ||
				string.IsNullOrWhiteSpace(txtBookTitle.Text))
			{
				lblStatus.Text = "Enter both an author name and a book title.";
				return;
			}

			using (var context = new BookstoreContext())
			{
				// Reuse the author if they are already stored.
				Author? author = context.Authors
					.FirstOrDefault(a => a.Name == txtAuthorName.Text);

				if (author == null)
				{
					author = new Author { Name = txtAuthorName.Text };
					context.Authors.Add(author);
				}

				context.Books.Add(new Book { Title = txtBookTitle.Text, Author = author });
				context.SaveChanges();
			}

			lblStatus.Text = $"Added \"{txtBookTitle.Text}\".";
			ShowBooks();
		}

		// Task 5. Read: every book with the author it belongs to.
		private void ShowBooks()
		{
			using (var context = new BookstoreContext())
			{
				var books = context.Books
					.Include(b => b.Author)
					.OrderBy(b => b.BookID)
					.ToList();

				listBoxBooks.Items.Clear();
				foreach (var book in books)
				{
					listBoxBooks.Items.Add($"{book.BookID}: {book.Title} by {book.Author.Name}");
				}
			}
		}

		private void btnShowBooks_Click(object sender, EventArgs e)
		{
			ShowBooks();
			lblStatus.Text = $"{listBoxBooks.Items.Count} book(s) in the database.";
		}

		// Task 6. Update: change a book title and its author's name by BookID.
		private void btnUpdateBook_Click(object sender, EventArgs e)
		{
			if (!int.TryParse(txtBookID.Text, out int bookId))
			{
				lblStatus.Text = "Enter the BookID of the book to update.";
				return;
			}

			using (var context = new BookstoreContext())
			{
				Book? book = context.Books
					.Include(b => b.Author)
					.FirstOrDefault(b => b.BookID == bookId);

				if (book == null)
				{
					lblStatus.Text = $"No book with BookID {bookId}.";
					return;
				}

				if (!string.IsNullOrWhiteSpace(txtBookTitle.Text))
					book.Title = txtBookTitle.Text;

				if (!string.IsNullOrWhiteSpace(txtAuthorName.Text))
					book.Author.Name = txtAuthorName.Text;

				context.SaveChanges();
				lblStatus.Text = $"Updated book {bookId}.";
			}

			ShowBooks();
		}

		// Task 7. Delete a book by BookID.
		private void btnDeleteBook_Click(object sender, EventArgs e)
		{
			if (!int.TryParse(txtBookID.Text, out int bookId))
			{
				lblStatus.Text = "Enter the BookID of the book to delete.";
				return;
			}

			using (var context = new BookstoreContext())
			{
				Book? book = context.Books.FirstOrDefault(b => b.BookID == bookId);
				if (book == null)
				{
					lblStatus.Text = $"No book with BookID {bookId}.";
					return;
				}

				context.Books.Remove(book);
				context.SaveChanges();
				lblStatus.Text = $"Deleted book {bookId}.";
			}

			ShowBooks();
		}

		// Task 7. Search every book written by one author.
		private void btnSearchByAuthor_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtSearchAuthor.Text))
			{
				lblStatus.Text = "Enter an author name to search for.";
				return;
			}

			using (var context = new BookstoreContext())
			{
				var books = context.Books
					.Include(b => b.Author)
					.Where(b => b.Author.Name == txtSearchAuthor.Text)
					.OrderBy(b => b.BookID)
					.ToList();

				listBoxBooks.Items.Clear();
				foreach (var book in books)
				{
					listBoxBooks.Items.Add($"{book.BookID}: {book.Title} by {book.Author.Name}");
				}

				lblStatus.Text = $"{books.Count} book(s) by {txtSearchAuthor.Text}.";
			}
		}
	}
}
