using System.Net.Http;
using System.Text.Json;

namespace lab9
{
	public class BookResult
	{
		public string Title { get; set; } = "";
		public string Authors { get; set; } = "";
		public string Publisher { get; set; } = "";
		public string PublishedDate { get; set; } = "";
		public string Categories { get; set; } = "";
		public string Description { get; set; } = "";
		public double? Rating { get; set; }

		public override string ToString() => $"{Title} by {Authors} ({PublishedDate})";
	}

	// Task 1 and 2. One HttpClient for the whole application: creating one per
	// request exhausts sockets under load.
	public static class BooksApi
	{
		private static readonly HttpClient Client = new HttpClient
		{
			Timeout = TimeSpan.FromSeconds(15)
		};

		public const string GoogleBooks = "Google Books";
		public const string OpenLibrary = "Open Library";

		// Task 1. Fetch one book by ISBN from the Google Books API.
		public static async Task<List<BookResult>> GetBookByIsbnAsync(string isbn)
		{
			string url = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{Uri.EscapeDataString(isbn)}";
			return ParseGoogle(await GetJsonAsync(url));
		}

		// Task 3. Search by author, with startIndex/maxResults driving pagination.
		public static async Task<List<BookResult>> SearchByAuthorAsync(
			string author, int startIndex, int pageSize)
		{
			string url = "https://www.googleapis.com/books/v1/volumes" +
				$"?q=inauthor:{Uri.EscapeDataString(author)}" +
				$"&startIndex={startIndex}&maxResults={pageSize}";
			return ParseGoogle(await GetJsonAsync(url));
		}

		// Fallback source. Google Books rate-limits anonymous callers per IP and
		// returns 429; Open Library answers the same questions without a key, so
		// the feature can still be demonstrated. Which source answered is always
		// reported back to the user rather than hidden.
		public static async Task<List<BookResult>> SearchOpenLibraryAsync(
			string query, int page, int pageSize)
		{
			string url = "https://openlibrary.org/search.json" +
				$"?q={Uri.EscapeDataString(query)}&page={page}&limit={pageSize}" +
				"&fields=title,author_name,first_publish_year,publisher,subject,ratings_average";
			return ParseOpenLibrary(await GetJsonAsync(url));
		}

		private static async Task<JsonDocument> GetJsonAsync(string url)
		{
			HttpResponseMessage response = await Client.GetAsync(url);
			response.EnsureSuccessStatusCode();
			return JsonDocument.Parse(await response.Content.ReadAsStringAsync());
		}

		private static List<BookResult> ParseGoogle(JsonDocument doc)
		{
			var results = new List<BookResult>();
			using (doc)
			{
				if (!doc.RootElement.TryGetProperty("items", out JsonElement items))
					return results;

				foreach (JsonElement item in items.EnumerateArray())
				{
					if (!item.TryGetProperty("volumeInfo", out JsonElement info)) continue;

					results.Add(new BookResult
					{
						Title = Text(info, "title"),
						Authors = Join(info, "authors"),
						Publisher = Text(info, "publisher"),
						PublishedDate = Text(info, "publishedDate"),
						Categories = Join(info, "categories"),
						Description = Text(info, "description")
					});
				}
			}
			return results;
		}

		private static List<BookResult> ParseOpenLibrary(JsonDocument doc)
		{
			var results = new List<BookResult>();
			using (doc)
			{
				if (!doc.RootElement.TryGetProperty("docs", out JsonElement docs))
					return results;

				foreach (JsonElement d in docs.EnumerateArray())
				{
					string year = d.TryGetProperty("first_publish_year", out JsonElement y)
						? y.ToString() : "";
					double? rating = d.TryGetProperty("ratings_average", out JsonElement r)
						&& r.ValueKind == JsonValueKind.Number ? r.GetDouble() : (double?)null;

					results.Add(new BookResult
					{
						Title = Text(d, "title"),
						Authors = Join(d, "author_name"),
						Publisher = Join(d, "publisher"),
						PublishedDate = year,
						Categories = Join(d, "subject"),
						Description = "",
						Rating = rating
					});
				}
			}
			return results;
		}

		private static string Text(JsonElement parent, string name) =>
			parent.TryGetProperty(name, out JsonElement v) && v.ValueKind == JsonValueKind.String
				? v.GetString() ?? "" : "";

		private static string Join(JsonElement parent, string name)
		{
			if (!parent.TryGetProperty(name, out JsonElement v) || v.ValueKind != JsonValueKind.Array)
				return "";
			return string.Join(", ", v.EnumerateArray()
				.Where(e => e.ValueKind == JsonValueKind.String)
				.Select(e => e.GetString())
				.Take(12));
		}
	}
}
