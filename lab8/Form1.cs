using System.Net.Http;
using System.Text;

namespace lab8
{
	public partial class Form1 : Form
	{
		// Task 3. Pagination state for the author search.
		private const int PageSize = 10;
		private int currentPage = 0;
		private string currentAuthor = "";

		public Form1()
		{
			InitializeComponent();
		}

		// Task 1. Fetch one book by ISBN and show its details.
		// Task 2. Every failure mode the call can hit is caught and turned into a
		// message rather than an unhandled exception.
		private async void btnFetchBook_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtISBN.Text))
			{
				lblStatus.Text = "Enter an ISBN first.";
				return;
			}

			SetBusy(true, "Calling the Google Books API...");

			try
			{
				List<BookResult> books = await BooksApi.GetBookByIsbnAsync(txtISBN.Text.Trim());
				ShowDetails(books, BooksApi.GoogleBooks);
			}
			catch (HttpRequestException ex)
			{
				// 429 from Google Books is the common one on a shared address.
				await FallbackByIsbnAsync(txtISBN.Text.Trim(),
					$"{BooksApi.GoogleBooks} returned {(int?)ex.StatusCode} {ex.StatusCode}");
			}
			catch (TaskCanceledException)
			{
				lblStatus.Text = "The request timed out after 15 seconds.";
				txtBookDetails.Text = "No response from the API within the timeout.";
			}
			catch (Exception ex)
			{
				lblStatus.Text = $"Unexpected error: {ex.Message}";
			}
			finally
			{
				SetBusy(false, null);
			}
		}

		private async Task FallbackByIsbnAsync(string isbn, string whyPrimaryFailed)
		{
			try
			{
				List<BookResult> books = await BooksApi.SearchOpenLibraryAsync(isbn, 1, 5);
				ShowDetails(books, BooksApi.OpenLibrary, whyPrimaryFailed);
			}
			catch (Exception ex)
			{
				lblStatus.Text = $"Both sources failed: {ex.Message}";
				txtBookDetails.Text = $"{whyPrimaryFailed}\r\nFallback also failed: {ex.Message}";
			}
		}

		private void ShowDetails(List<BookResult> books, string source, string? whyPrimaryFailed = null)
		{
			if (books.Count == 0)
			{
				txtBookDetails.Text = $"No book found ({source}).";
				lblStatus.Text = $"{source}: no results.";
				return;
			}

			BookResult b = books[0];
			var sb = new StringBuilder();
			sb.AppendLine($"Source:    {source}");
			if (whyPrimaryFailed != null)
			{
				sb.AppendLine($"Note:      {whyPrimaryFailed}, so the fallback source answered.");
			}
			sb.AppendLine();
			sb.AppendLine($"Title:     {b.Title}");
			sb.AppendLine($"Authors:   {b.Authors}");
			sb.AppendLine($"Publisher: {b.Publisher}");
			sb.AppendLine($"Published: {b.PublishedDate}");
			sb.AppendLine($"Categories:{b.Categories}");
			if (!string.IsNullOrWhiteSpace(b.Description))
			{
				sb.AppendLine();
				sb.AppendLine("Description:");
				sb.AppendLine(b.Description.Length > 600
					? b.Description.Substring(0, 600) + "..."
					: b.Description);
			}

			txtBookDetails.Text = sb.ToString();
			lblStatus.Text = $"Fetched from {source}.";
		}

		// Task 3. Search by author, one page at a time.
		private async void btnSearchAuthor_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtAuthor.Text))
			{
				lblStatus.Text = "Enter an author name first.";
				return;
			}

			currentAuthor = txtAuthor.Text.Trim();
			currentPage = 0;
			await LoadAuthorPageAsync();
		}

		private async void btnNextPage_Click(object sender, EventArgs e)
		{
			currentPage++;
			await LoadAuthorPageAsync();
		}

		private async void btnPreviousPage_Click(object sender, EventArgs e)
		{
			if (currentPage > 0) currentPage--;
			await LoadAuthorPageAsync();
		}

		private async Task LoadAuthorPageAsync()
		{
			if (string.IsNullOrWhiteSpace(currentAuthor)) return;

			SetBusy(true, $"Searching page {currentPage + 1}...");
			string source = BooksApi.GoogleBooks;
			List<BookResult> books = new List<BookResult>();

			try
			{
				books = await BooksApi.SearchByAuthorAsync(
					currentAuthor, currentPage * PageSize, PageSize);
			}
			catch (HttpRequestException ex)
			{
				lblStatus.Text = $"{BooksApi.GoogleBooks} returned {ex.StatusCode}; using the fallback.";
				try
				{
					books = await BooksApi.SearchOpenLibraryAsync(
						currentAuthor, currentPage + 1, PageSize);
					source = BooksApi.OpenLibrary;
				}
				catch (Exception inner)
				{
					lblStatus.Text = $"Both sources failed: {inner.Message}";
					SetBusy(false, null);
					return;
				}
			}
			catch (TaskCanceledException)
			{
				lblStatus.Text = "The search timed out.";
				SetBusy(false, null);
				return;
			}

			listBoxResults.Items.Clear();
			foreach (BookResult b in books)
			{
				listBoxResults.Items.Add(b.ToString());
			}

			lblPage.Text = $"Page {currentPage + 1}  ({books.Count} shown, source: {source})";
			btnPreviousPage.Enabled = currentPage > 0;
			btnNextPage.Enabled = books.Count == PageSize;
			if (!lblStatus.Text.Contains("fallback"))
				lblStatus.Text = $"{books.Count} result(s) from {source}.";

			SetBusy(false, null);
		}

		private void SetBusy(bool busy, string? message)
		{
			btnFetchBook.Enabled = !busy;
			btnSearchAuthor.Enabled = !busy;
			btnNextPage.Enabled = !busy && btnNextPage.Enabled;
			btnPreviousPage.Enabled = !busy && btnPreviousPage.Enabled;
			if (busy && message != null) lblStatus.Text = message;
		}
	}
}
