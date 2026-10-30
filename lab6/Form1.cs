using Microsoft.EntityFrameworkCore;

namespace lab6
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		// Task 1. Event-driven: the click handler is what starts the work, and
		// async void is the one place it is allowed, because an event handler
		// has nowhere to return a Task to.
		private async void btnFetchBooks_Click(object sender, EventArgs e)
		{
			SetBusy(true, "Fetching books...");

			// Task 3. IProgress reports back onto the UI thread, so the handler
			// can update the bar without touching Invoke.
			var progress = new Progress<int>(value => progressBar.Value = value);

			try
			{
				List<Book> books = await FetchBooksAsync(progress);
				ShowBooks(books);
				lblStatus.Text = $"Fetched {books.Count} book(s).";
			}
			finally
			{
				SetBusy(false, null);
			}
		}

		private async Task<List<Book>> FetchBooksAsync(IProgress<int> progress)
		{
			progress.Report(20);

			using (var context = new BookstoreContext())
			{
				// ToListAsync releases the UI thread while SQL Server works.
				List<Book> books = await context.Books
					.Include(b => b.Author)
					.OrderBy(b => b.BookID)
					.ToListAsync();

				progress.Report(70);
				await Task.Delay(300);   // makes the progress visible
				progress.Report(100);

				return books;
			}
		}

		private void ShowBooks(List<Book> books)
		{
			listBoxBooks.Items.Clear();
			foreach (Book book in books)
			{
				listBoxBooks.Items.Add($"{book.BookID}: {book.Title} by {book.Author.Name}");
			}
		}

		// Task 2. Asynchronous save.
		private async void btnAddBook_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtAuthorName.Text) ||
				string.IsNullOrWhiteSpace(txtBookTitle.Text))
			{
				lblStatus.Text = "Enter both an author name and a book title.";
				return;
			}

			SetBusy(true, "Saving...");

			try
			{
				using (var context = new BookstoreContext())
				{
					Author? author = await context.Authors
						.FirstOrDefaultAsync(a => a.Name == txtAuthorName.Text);

					if (author == null)
					{
						author = new Author { Name = txtAuthorName.Text };
						await context.Authors.AddAsync(author);
					}

					await context.Books.AddAsync(
						new Book { Title = txtBookTitle.Text, Author = author });

					await context.SaveChangesAsync();
				}

				lblStatus.Text = $"Saved \"{txtBookTitle.Text}\".";
			}
			finally
			{
				SetBusy(false, null);
			}

			await RefreshAsync();
		}

		// Task 3. Asynchronous update.
		private async void btnUpdateBook_Click(object sender, EventArgs e)
		{
			if (!int.TryParse(txtBookID.Text, out int bookId))
			{
				lblStatus.Text = "Enter the BookID of the book to update.";
				return;
			}

			SetBusy(true, "Updating...");

			try
			{
				using (var context = new BookstoreContext())
				{
					Book? book = await context.Books
						.Include(b => b.Author)
						.FirstOrDefaultAsync(b => b.BookID == bookId);

					if (book == null)
					{
						lblStatus.Text = $"No book with BookID {bookId}.";
						return;
					}

					if (!string.IsNullOrWhiteSpace(txtBookTitle.Text))
						book.Title = txtBookTitle.Text;

					if (!string.IsNullOrWhiteSpace(txtAuthorName.Text))
						book.Author.Name = txtAuthorName.Text;

					await context.SaveChangesAsync();
					lblStatus.Text = $"Updated book {bookId}.";
				}
			}
			finally
			{
				SetBusy(false, null);
			}

			await RefreshAsync();
		}

		// Task 3. Asynchronous delete.
		private async void btnDeleteBook_Click(object sender, EventArgs e)
		{
			if (!int.TryParse(txtBookID.Text, out int bookId))
			{
				lblStatus.Text = "Enter the BookID of the book to delete.";
				return;
			}

			SetBusy(true, "Deleting...");

			try
			{
				using (var context = new BookstoreContext())
				{
					Book? book = await context.Books
						.FirstOrDefaultAsync(b => b.BookID == bookId);

					if (book == null)
					{
						lblStatus.Text = $"No book with BookID {bookId}.";
						return;
					}

					context.Books.Remove(book);
					await context.SaveChangesAsync();
					lblStatus.Text = $"Deleted book {bookId}.";
				}
			}
			finally
			{
				SetBusy(false, null);
			}

			await RefreshAsync();
		}

		// Task 3. Asynchronous search by title.
		private async void btnSearchTitle_Click(object sender, EventArgs e)
		{
			SetBusy(true, "Searching...");

			try
			{
				using (var context = new BookstoreContext())
				{
					List<Book> books = await context.Books
						.Include(b => b.Author)
						.Where(b => b.Title.Contains(txtSearchTitle.Text))
						.OrderBy(b => b.BookID)
						.ToListAsync();

					ShowBooks(books);
					lblStatus.Text = $"{books.Count} book(s) matching \"{txtSearchTitle.Text}\".";
				}
			}
			finally
			{
				SetBusy(false, null);
			}
		}

		private async Task RefreshAsync()
		{
			using (var context = new BookstoreContext())
			{
				ShowBooks(await context.Books
					.Include(b => b.Author)
					.OrderBy(b => b.BookID)
					.ToListAsync());
			}
		}

		// Disabling the buttons while work is in flight is the visible proof
		// that the UI thread is still responding.
		private void SetBusy(bool busy, string? message)
		{
			btnFetchBooks.Enabled = !busy;
			btnAddBook.Enabled = !busy;
			btnUpdateBook.Enabled = !busy;
			btnDeleteBook.Enabled = !busy;
			btnSearchTitle.Enabled = !busy;

			if (busy)
			{
				progressBar.Value = 0;
				if (message != null) lblStatus.Text = message;
			}
		}
	}
}
