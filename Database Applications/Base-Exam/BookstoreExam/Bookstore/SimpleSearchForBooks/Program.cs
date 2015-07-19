namespace SimpleSearchForBooks
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Xml.Linq;

    using BookstoreData;

    public class Program
    {
        public static void Main()
        {
            var query = XDocument.Load("../../simple-query.xml");

            var titleElement = query.Root.Element("title");
            var authorElement = query.Root.Element("author");
            var isbnElement = query.Root.Element("isbn");

            var context = new BookstoreEntities();
            var books = context.Books.AsQueryable();
            if (titleElement != null)
            {
                books = books.Where(b => b.Title == titleElement.Value);
            }

            if (authorElement != null)
            {
                books = books.Where(b => b.Authors.Any(a => a.Name == authorElement.Value));
            }

            if (isbnElement != null)
            {
                books = books.Where(b => b.ISBN == isbnElement.Value);
            }

            var booksMinData = books.Select(b => new
              {
                  b.Title,
                  ReviewsCount = b.Reviews.Count()
              }).ToList();


            if (!booksMinData.Any())
            {
                Console.WriteLine("Nothing found");
            }
            else
            {
                Console.WriteLine("{0} books found", booksMinData.Count());

                foreach (var book in booksMinData)
                {
                    if (book.ReviewsCount > 0)
                    {
                        Console.WriteLine("{0} --> {1} ", book.Title, book.ReviewsCount);
                    }
                    else
                    {
                        Console.WriteLine("{0} --> No reviews ", book.Title);
                    }
                }
            }
        }
    }
}
