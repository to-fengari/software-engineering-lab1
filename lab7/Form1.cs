using Microsoft.EntityFrameworkCore;

namespace lab7
{
	public partial class Form1 : Form
	{
		// Task 1. Pagination state: only one page of rows is ever fetched.
		private const int PageSize = 5;
		private int currentPage = 1;
		private int totalPages = 1;

		public Form1()
		{
			InitializeComponent();
		}

		private async void Form1_Load(object sender, EventArgs e)
		{
			await LoadPageAsync();
		}

		// Task 1. Skip/Take turn into OFFSET/FETCH in SQL, so the database
		// returns one page rather than the whole table.
		private async Task LoadPageAsync()
		{
			try
			{
				using (var context = new BookstoreContext())
				{
					int total = await context.Books.CountAsync();
					totalPages = Math.Max(1, (int)Math.Ceiling(total / (double)PageSize));
					currentPage = Math.Clamp(currentPage, 1, totalPages);

					List<Book> books = await context.Books
						.Include(b => b.Author)
						.OrderBy(b => b.BookID)
						.Skip((currentPage - 1) * PageSize)
						.Take(PageSize)
						.ToListAsync();

					listBoxBooks.Items.Clear();
					foreach (Book book in books)
					{
						listBoxBooks.Items.Add($"{book.BookID}: {book.Title} by {book.Author.Name}");
					}

					lblPageNumber.Text = $"Page {currentPage} of {totalPages}  ({total} books)";
					btnPreviousPage.Enabled = currentPage > 1;
					btnNextPage.Enabled = currentPage < totalPages;
				}
			}
			catch (Exception ex)
			{
				lblStatus.Text = $"Could not load books: {ex.Message}";
			}
		}

		private async void btnNextPage_Click(object sender, EventArgs e)
		{
			currentPage++;
			await LoadPageAsync();
		}

		private async void btnPreviousPage_Click(object sender, EventArgs e)
		{
			currentPage--;
			await LoadPageAsync();
		}

		// Task 2. Error handling around an async save. Each failure the caller
		// can actually do something about gets its own message.
		private async Task<bool> SaveBookAsync(string authorName, string title)
		{
			try
			{
				using (var context = new BookstoreContext())
				{
					Author? author = await context.Authors
						.FirstOrDefaultAsync(a => a.Name == authorName);

					if (author == null)
					{
						author = new Author { Name = authorName };
						await context.Authors.AddAsync(author);
					}

					await context.Books.AddAsync(new Book { Title = title, Author = author });
					await context.SaveChangesAsync();
					return true;
				}
			}
			catch (DbUpdateException ex)
			{
				lblStatus.Text = $"The database rejected the save: {ex.InnerException?.Message ?? ex.Message}";
			}
			catch (Exception ex)
			{
				lblStatus.Text = $"Could not save: {ex.Message}";
			}

			return false;
		}

		private async void btnAddBook_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtAuthorName.Text) ||
				string.IsNullOrWhiteSpace(txtBookTitle.Text))
			{
				lblStatus.Text = "Enter both an author name and a book title.";
				return;
			}

			if (await SaveBookAsync(txtAuthorName.Text, txtBookTitle.Text))
			{
				lblStatus.Text = $"Saved \"{txtBookTitle.Text}\".";
				await LoadPageAsync();
			}
		}

		// Task 3. Asynchronous file I/O. WriteAllLinesAsync keeps the UI alive
		// while the file is written.
		private async Task ExportBooksAsync(string path)
		{
			using (var context = new BookstoreContext())
			{
				List<string> lines = await context.Books
					.Include(b => b.Author)
					.OrderBy(b => b.BookID)
					.Select(b => b.Title + "|" + b.Author.Name)
					.ToListAsync();

				await File.WriteAllLinesAsync(path, lines);
				lblStatus.Text = $"Exported {lines.Count} book(s) to {Path.GetFileName(path)}.";
			}
		}

		private async void btnExportBooks_Click(object sender, EventArgs e)
		{
			try
			{
				await ExportBooksAsync(ExportPath);
			}
			catch (IOException ex)
			{
				lblStatus.Text = $"Could not write the file: {ex.Message}";
			}
		}

		// Task 4. Asynchronous import, with the file-missing case handled.
		private async void btnImportBooks_Click(object sender, EventArgs e)
		{
			try
			{
				string[] lines = await File.ReadAllLinesAsync(ExportPath);
				int added = 0;

				foreach (string line in lines)
				{
					string[] parts = line.Split('|');
					if (parts.Length != 2) continue;

					if (await SaveBookAsync(parts[1].Trim(), parts[0].Trim() + " (imported)"))
						added++;
				}

				lblStatus.Text = $"Imported {added} book(s) from {Path.GetFileName(ExportPath)}.";
				await LoadPageAsync();
			}
			catch (FileNotFoundException)
			{
				lblStatus.Text = "Export the books first, there is no file to import.";
			}
			catch (Exception ex)
			{
				lblStatus.Text = $"Could not import: {ex.Message}";
			}
		}

		// Task 4. Asynchronous search, also wrapped in error handling.
		private async void btnSearch_Click(object sender, EventArgs e)
		{
			try
			{
				using (var context = new BookstoreContext())
				{
					List<Book> books = await context.Books
						.Include(b => b.Author)
						.Where(b => b.Title.Contains(txtSearch.Text))
						.OrderBy(b => b.BookID)
						.ToListAsync();

					listBoxBooks.Items.Clear();
					foreach (Book book in books)
					{
						listBoxBooks.Items.Add($"{book.BookID}: {book.Title} by {book.Author.Name}");
					}

					lblPageNumber.Text = $"Search results for \"{txtSearch.Text}\"";
					lblStatus.Text = $"{books.Count} match(es).";
					btnNextPage.Enabled = false;
					btnPreviousPage.Enabled = false;
				}
			}
			catch (Exception ex)
			{
				lblStatus.Text = $"Search failed: {ex.Message}";
			}
		}

		private static string ExportPath =>
			Path.Combine(Application.StartupPath, "books-export.txt");
	}
}
