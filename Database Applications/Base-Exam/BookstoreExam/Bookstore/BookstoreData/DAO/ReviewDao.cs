namespace BookstoreData.DAO
{
    using System;
    using System.Linq;

    public static class ReviewDao
    {
        public static Review CreateReview(BookstoreEntities entities, string text)
        {
            return CreateReview(entities, text, null, null);
        }

        public static Review CreateReview(BookstoreEntities entities, string text, string date)
        {
            return CreateReview(entities, text, date, null);
        }


        public static Review CreateReview(BookstoreEntities entities, string text, string dateStr, string authorName)
        {
            var review = new Review() { Date = DateTime.Now, Content = text };
            if (authorName != null)
            {
                var author = entities.Authors.FirstOrDefault(a => a.Name == authorName);
                review.Author = author;
            }

            if (dateStr != null)
            {
                var date = DateTime.Parse(dateStr);
                review.Date = date;
            }

            entities.Reviews.Add(review);

            return review;
        }
    }
}
