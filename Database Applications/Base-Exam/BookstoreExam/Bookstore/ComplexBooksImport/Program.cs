namespace ComplexBooksImport
{
    using BookstoreData;

    using SimpleBooksImport;

    public class Program
    { 
        public static void Main(string[] args)
        {
            var bookstore = new BookstoreEntities();
            var import = new Import(bookstore);
            import.LoadDocument("../../complex-books.xml");
            import.BooksComplexParse();
        }
    }
}
