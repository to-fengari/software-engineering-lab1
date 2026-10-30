using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab3;

namespace BookstoreTests
{
	// Task 1: the base class and its subclasses are built and read back.
	[TestClass]
	public class BookTests
	{
		[TestMethod]
		public void TestBookCreation()
		{
			Book book = new Book { Title = "C# Programming", Author = "John Smith" };
			Assert.AreEqual("C# Programming", book.Title);
			Assert.AreEqual("John Smith", book.Author);
		}

		[TestMethod]
		public void TestMagazineCreation()
		{
			Magazine magazine = new Magazine
			{
				Title = "Tech Weekly",
				Author = "Jane Doe",
				IssueNumber = 12
			};
			Assert.AreEqual("Tech Weekly", magazine.Title);
			Assert.AreEqual(12, magazine.IssueNumber);
		}
	}

	// Task 1: the whole point of the exercise, that the derived GetInfo runs
	// even though the array is typed as Book.
	[TestClass]
	public class PolymorphismTests
	{
		[TestMethod]
		public void TestPolymorphism_GetInfo_Method()
		{
			Book[] books = new Book[]
			{
				new Book { Title = "Generic Book", Author = "John Smith" },
				new Magazine { Title = "Tech Weekly", Author = "Jane Doe", IssueNumber = 12 },
				new Ebook { Title = "Learn C#", Author = "Mark Jones", FileSizeMB = 5 }
			};

			Assert.AreEqual("Generic Book by John Smith", books[0].GetInfo());
			Assert.AreEqual("Tech Weekly - Issue 12", books[1].GetInfo());
			Assert.AreEqual("Learn C# (Ebook, 5MB)", books[2].GetInfo());
		}

		[TestMethod]
		public void TestPolymorphism_CoversTask3Classes()
		{
			Book[] books = new Book[]
			{
				new Textbook { Title = "Software Design", Author = "A. Writer", Subject = "Engineering" },
				new AudioBook { Title = "Clean Code", Duration = 420, Narrator = "R. Reader" }
			};

			Assert.AreEqual("Software Design by A. Writer (Textbook, Engineering)", books[0].GetInfo());
			Assert.AreEqual("Clean Code (Audiobook, 420 min, read by R. Reader)", books[1].GetInfo());
		}
	}

	// Task 2 and Task 3: invalid data has to be rejected, not stored.
	[TestClass]
	public class ValidationTests
	{
		[TestMethod]
		public void TestBookWithEmptyTitleIsRejected()
		{
			Assert.Throws<ArgumentException>(() =>
				new Book { Title = "", Author = "John Smith" });
		}

		[TestMethod]
		public void TestBookWithWhitespaceTitleIsRejected()
		{
			Assert.Throws<ArgumentException>(() =>
				new Book { Title = "   ", Author = "John Smith" });
		}

		[TestMethod]
		public void TestMagazineWithNegativeIssueNumberIsRejected()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() =>
				new Magazine { Title = "Tech Weekly", IssueNumber = -1 });
		}

		[TestMethod]
		public void TestTextbookWithEmptySubjectIsRejected()
		{
			Assert.Throws<ArgumentException>(() =>
				new Textbook { Title = "Software Design", Author = "A. Writer", Subject = "" });
		}

		[TestMethod]
		public void TestValidTextbookIsAccepted()
		{
			Textbook textbook = new Textbook
			{
				Title = "Software Design",
				Author = "A. Writer",
				Subject = "Engineering"
			};
			Assert.AreEqual("Engineering", textbook.Subject);
		}
	}
}
