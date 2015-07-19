namespace SimpleBooksImport
{
    using BookstoreData;

    public class Program
    {
        public static void Main(string[] args)
        {
            var bookstore = new BookstoreEntities();
            var parse = new Import(bookstore);
            parse.LoadDocument("../../simple-books.xml");
            parse.SimpleBooksParse();
        }


    }
}
