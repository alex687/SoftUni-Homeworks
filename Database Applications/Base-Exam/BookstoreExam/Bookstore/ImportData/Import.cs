namespace SimpleBooksImport
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Xml.Linq;
    using System.Xml.Schema;

    using BookstoreData;
    using BookstoreData.DAO;

    public class Import
    {
        private BookstoreEntities entities;

        private XDocument document;

        public Import(BookstoreEntities entities)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            this.entities = entities;
        }

        protected BookstoreEntities Entities
        {
            get
            {
                return this.entities;
            }
        }

        protected XDocument Document
        {
            get
            {
                return this.document;
            }
        }

        public void LoadDocument(string uri)
        {
            this.document = XDocument.Load(uri);
        }

        public void SimpleBooksParse()
        {
            var books = this.GetBooksXml();
            foreach (var bookXml in books)
            {
                var title = bookXml.Element("title").Value;
                var book = new Book { Title = title };

                var authorName = bookXml.Element("author").Value;
                var author = AuthorDao.GetOrCreateAuthor(this.Entities, authorName);
                book.Authors.Add(author);

                this.BookSetNotRequiredProperty("ISBN", "isbn", bookXml, book);
                this.BookSetNotRequiredProperty("Price", "price", bookXml, book);
                this.BookSetNotRequiredProperty("Url", "web-site", bookXml, book);

                this.Entities.Books.Add(book);
                this.Entities.SaveChanges();
            }
        }


        public void BooksComplexParse()
        {
            var books = this.GetBooksXml();
            foreach (var bookXml in books)
            {
                var title = bookXml.Element("title").Value;
                var book = new Book { Title = title };

                var authorsXml = bookXml.Elements("authors");
                var authors = authorsXml.Select(authorXml => AuthorDao.GetOrCreateAuthor(this.Entities, authorXml.Value)).ToList();
                book.Authors = authors;

                this.BookSetNotRequiredProperty("ISBN", "isbn", bookXml, book);
                this.BookSetNotRequiredProperty("Price", "price", bookXml, book);
                this.BookSetNotRequiredProperty("Url", "web-site", bookXml, book);

                var reviewsXml = bookXml.Elements("reviews");
                var reviews = new List<Review>();
                foreach (var reviewXml in reviewsXml)
                {
                    var dateAttribute = reviewXml.Attribute("date");
                    string date = null;
                    if (dateAttribute != null)
                    {
                        date = dateAttribute.Value;
                    }
            
                    var authorAttribute = reviewXml.Attribute("author");
                    string author = null;
                    if (authorAttribute != null)
                    {
                        author = authorAttribute.Value;
                    }


                    reviews.Add(ReviewDao.CreateReview(this.Entities, reviewXml.Value, date, author));
                }

                book.Reviews = reviews;

                this.Entities.Books.Add(book);
                this.Entities.SaveChanges();
            }
        }

        protected IEnumerable<XElement> GetBooksXml()
        {
            if (this.document.Element("catalog") == null)
            {
                throw new XmlSchemaException("No root element (catalog)");
            }

            var books = document.Element("catalog").Elements("book");

            return books;
        }

        protected void BookSetNotRequiredProperty(string propertyName, string xmlTagName, XElement bookXml, Book book)
        {
            var element = bookXml.Element(xmlTagName);
            if (element == null)
            {
                return;
            }

            var bookType = book.GetType();
            var property = bookType.GetProperty(propertyName);

            object elementValue = element.Value;
            if (property.PropertyType.IsAssignableFrom(typeof(Nullable<decimal>)))
            {
                elementValue = decimal.Parse(element.Value);
            }

            property.SetValue(book, elementValue);
        }

        protected void BookSetAuthors(ICollection<Author> authors, Book book)
        {
            book.Authors = authors;
        }
    }
}
