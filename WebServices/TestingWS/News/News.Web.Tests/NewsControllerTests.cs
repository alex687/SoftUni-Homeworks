namespace News.Web.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using System.Web.Http.Routing;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using News.Data;
    using News.Data.Repositories;
    using News.Models;
    using News.Web.Controllers;
    using News.Web.Models.NewsItems;

    using Newtonsoft.Json;

    [TestClass]
    public class NewsControllerTests
    {
        [TestMethod]
        public void TestingGetAllmethodShouldSucceed()
        {
            var news = new List<NewsItem>
            {
                new NewsItem
                {
                    Title = "FirstNews", 
                    Content = "FirstNewsContent", 
                    PublishDate = DateTime.Now,
                    UserId = "2",
                    User = new ApplicationUser() {UserName = "Birko" }
                }, 
                new NewsItem
                {
                    Title = "SecondNews", 
                    Content = "SecondNewsContent", 
                    PublishDate = DateTime.Now.AddDays(-3),
                    UserId = "2",
                    User = new ApplicationUser() { UserName = "Birko" }
                }, 
                new NewsItem
                {
                    Title = "ThirdNews", 
                    Content = "ThirdNewsContent", 
                    PublishDate = DateTime.Now.AddDays(-10),
                    UserId = "2",
                    User = new ApplicationUser() {UserName = "Kapka"}
                }
            };

            var dataMock = new Mock<INewsData>();
            dataMock.Setup(r => r.News).Returns(this.GetMockedNewsItem(news));


            var controller = new NewsController(dataMock.Object);
            this.SetupController(controller, "NewsController");
            var result = controller.Get().ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            var content = result.Content.ReadAsStringAsync().Result;
            var resultNews = JsonConvert.DeserializeObject<List<NewsItemOutputModel>>(content);
            var exprectedNewsItems = news.Select(NewsItemOutputModel.Project);

            for (int i = 0; i < resultNews.Count; i++)
            {
                Assert.AreEqual(news[i].Id, resultNews[i].Id);
                Assert.AreEqual(news[i].Title, resultNews[i].Title);
                Assert.AreEqual(news[i].Content, resultNews[i].Content);
                Assert.AreEqual(news[i].PublishDate, resultNews[i].PublishDate);
            }
        }

        [TestMethod]
        public void PostNewsItemWithValidDataShouldSucceed()
        {
            var news = new List<NewsItem>
            {
                new NewsItem
                {
                    Title = "FirstNews", 
                    Content = "FirstNewsContent", 
                    PublishDate = DateTime.Now,
                    UserId = "2",
                    User = new ApplicationUser() {UserName = "Birko" }
                }, 
                new NewsItem
                {
                    Title = "SecondNews", 
                    Content = "SecondNewsContent", 
                    PublishDate = DateTime.Now.AddDays(-3),
                    UserId = "2",
                    User = new ApplicationUser() { UserName = "Birko" }
                }, 
                new NewsItem
                {
                    Title = "ThirdNews", 
                    Content = "ThirdNewsContent", 
                    PublishDate = DateTime.Now.AddDays(-10),
                    UserId = "2",
                    User = new ApplicationUser() {UserName = "Kapka"}
                }
            };

            var dataMock = new Mock<INewsData>();
            dataMock.Setup(r => r.News).Returns(this.GetMockedNewsItem(news));
          
            var controller = new NewsController(dataMock.Object);
            this.SetupController(controller, "NewsController");

            var newNewsItem = new NewsItemOutputModel()
            {
                Title = "ThirdNews",
                Content = "ThirdNewsContent",
                PublishDate = DateTime.Now.AddDays(8)
            };
            var result = controller.Post(newNewsItem).ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
            Assert.AreEqual(newNewsItem.Title, news.Last().Title);
            Assert.AreEqual(newNewsItem.Content, news.Last().Content);
            Assert.IsNotNull(news.Last().PublishDate);
        }

        [TestMethod]
        public void PutNewsItemWithValidDataShouldSucceed()
        {
            var news = new List<NewsItem>
            {
                new NewsItem
                {
                    Id = 9,
                    Title = "FirstNews", 
                    Content = "FirstNewsContent", 
                    PublishDate = DateTime.Now,
                    UserId = "2",
                    User = new ApplicationUser() {UserName = "Birko" }
                }, 
                new NewsItem
                {
                    Id = 3,
                    Title = "SecondNews", 
                    Content = "SecondNewsContent", 
                    PublishDate = DateTime.Now.AddDays(-3),
                    UserId = "2",
                    User = new ApplicationUser() { UserName = "Birko" }
                }, 
                new NewsItem
                {
                    Id = 2,
                    Title = "ThirdNews", 
                    Content = "ThirdNewsContent", 
                    PublishDate = DateTime.Now.AddDays(-10),
                    UserId = "2",
                    User = new ApplicationUser() {UserName = "Kapka"}
                }
            };

            var dataMock = new Mock<INewsData>();
            dataMock.Setup(r => r.News).Returns(this.GetMockedNewsItem(news));

            var controller = new NewsController(dataMock.Object);
            this.SetupController(controller, "NewsController");

            var existingNewsItem = news.Where(n => n.Title == "FirstNews").Select(NewsItemOutputModel.Project).First();
            existingNewsItem.Title = "FirstNewsUpdatet";
            var id = existingNewsItem.Id;
           
            var result = controller.Put(id, existingNewsItem).ExecuteAsync(new CancellationToken()).Result;
            var itemAfterUpdate = news.First(n => n.Id == id);

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(itemAfterUpdate.Title, "FirstNewsUpdatet");
        }



        private IGenericRepository<NewsItem> GetMockedNewsItem(List<NewsItem> news)
        {
            var repoMock = new Mock<IGenericRepository<NewsItem>>();
            repoMock.Setup(r => r.All()).Returns(news.AsQueryable());
            repoMock.Setup(repo => repo.Add(It.IsAny<NewsItem>()))
              .Callback((NewsItem n) => news.Add(n));
            repoMock.Setup(repo => repo.Update(It.IsAny<NewsItem>()))
              .Callback((NewsItem n) => news[news.FindIndex(a => a.Id == n.Id)] = n);
           
            return repoMock.Object;
        }

        private void SetupController(ApiController controller, string controllerName)
        {
            string serverUrl = "http://sample-url.com";

            // Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            // Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            // Apply the routes to the controller
            controller.RequestContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary
                {
                    { "controller", controllerName }
                });
        }
    }
}
