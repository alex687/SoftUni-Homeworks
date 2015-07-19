namespace BookstoreData.DAO
{
    using System.Linq;

    public static class AuthorDao
    {
        public static Author GetOrCreateAuthor(BookstoreEntities entities, string authorName)
        {
            var author = entities.Authors.FirstOrDefault(a => a.Name == authorName);
            if (author == null)
            {
                author = new Author { Name = authorName };
                entities.Authors.Add(author);
            }

            return author;
        }
    }
}
