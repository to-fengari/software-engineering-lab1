using Microsoft.EntityFrameworkCore;

namespace lab7
{
	// Task 3. Entity models. Each class maps to a table, each property to a
	// column, and each object to a row.
	public class Author
	{
		public int AuthorID { get; set; }
		public string Name { get; set; } = "";

		// One author has many books. virtual allows lazy loading.
		public virtual ICollection<Book> Books { get; set; } = new List<Book>();
	}

	public class Book
	{
		public int BookID { get; set; }
		public string Title { get; set; } = "";

		// Foreign key back to Authors.
		public int AuthorID { get; set; }

		// Navigation property: the author this book belongs to.
		public virtual Author Author { get; set; } = null!;
	}

	// Task 4. The DbContext holds a DbSet per table and tracks changes so
	// SaveChanges can work out the SQL to run.
	public class BookstoreContext : DbContext
	{
		public DbSet<Book> Books { get; set; } = null!;
		public DbSet<Author> Authors { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(
				@"Server=(localdb)\MSSQLLocalDB;Database=BookstoreDB;" +
				"Trusted_Connection=True;TrustServerCertificate=True");
		}
	}
}
