namespace NewsRepository.Tests
{
    using System;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Transactions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using News.Data;
    using News.Models;

    [TestClass]
    public class NewsSystemRepositoryTests
    {
        private static TransactionScope tran;

        private static NewsDbContext DbContext = new NewsDbContext();

        private NewsData data = new NewsData(DbContext);

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            DbContext.Database.Delete();
            DbContext.Database.CreateIfNotExists();
        }

        [TestInitialize]
        public void TestInit()
        {
            // Start a new temporary transaction
            tran = new TransactionScope();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            // Rollback the temporary transaction
            tran.Dispose();
        }

        [TestMethod]
        public void GetBugsShouldReturnAllBugs()
        {
            DbContext = new NewsDbContext();
            this.data = new NewsData(DbContext);
            // Arrange -> prapare the objects

            this.data.News.Add(new NewsItem
            {
                Title = "Test",
                Content = "Test",
                PublishDate = DateTime.Now
            });

            this.data.News.Add(new NewsItem
            {
                Title = ";sdka;skladfh;aklsj kljoidflkjal",
                Content = "Test;Test;Test;Test",
                PublishDate = DateTime.Now.AddDays(-1)
            });
            this.data.SaveChanges();

            // Act -> perform some logic
            var news = this.data.News.All().Count();

            // Assert -> validate the results
            Assert.AreEqual(2, news);
        }

        [TestMethod]
        public void AddNewsItemThenGetTheNewItemSouldBeTheSame()
        {
            DbContext = new NewsDbContext();
            this.data = new NewsData(DbContext);

            var news = new NewsItem
            {
                Title = "Test",
                Content = "Test",
                PublishDate = DateTime.Now
            };

            this.data.News.Add(news);
            this.data.SaveChanges();

            Assert.AreEqual(news, this.data.News.All().OrderBy(n => n.Id).FirstOrDefault());
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CreateNewsItemWithoutContentDataShouldThrowException()
        {
            DbContext = new NewsDbContext();
            this.data = new NewsData(DbContext);

            this.data.News.Add(new NewsItem
            {
                Title = "Test",
                PublishDate = DateTime.Now
            });

            this.data.SaveChanges();
        }

        [TestMethod]
        public void ModifyExistingNewsItemWithValidData()
        {
            DbContext = new NewsDbContext();
            this.data = new NewsData(DbContext);

            var news = new NewsItem
            {
                Title = "Tesaat",
                Content = "Testaa",
                PublishDate = DateTime.Now
            };

            this.data.News.Add(news);
            this.data.SaveChanges();

            news.Title = "New title";
            this.data.SaveChanges();

            var itemAfterChange = this.data.News.All().FirstOrDefault();

            Assert.AreEqual("New title", itemAfterChange.Title);
        }
    }
}
