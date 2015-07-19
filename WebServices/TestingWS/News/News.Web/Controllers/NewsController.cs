namespace News.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using News.Data;
    using News.Models;
    using News.Web.Models.NewsItems;

    public class NewsController : BaseController
    {
        public NewsController()
            : base()
        {
        }

        public NewsController(INewsData newsData)
        {
            this.NewsData = newsData;
        }

        // GET api/news
        public IHttpActionResult Get()
        {
            var news =
                this.NewsData.News.All()
                    .OrderByDescending(n => n.PublishDate)
                    .Select(NewsItemOutputModel.Project);

            return this.Ok(news);
        }

        // POST api/news
        public IHttpActionResult Post([FromBody]NewsItemOutputModel newsItemOutput)
        {

            if (newsItemOutput == null)
            {
                this.ModelState.AddModelError("newsItem", "There is no news to add");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var userId = this.User.Identity.GetUserId();
            var newNewsItem = new NewsItem
               {
                   Content = newsItemOutput.Content,
                   PublishDate = newsItemOutput.PublishDate,
                   Title = newsItemOutput.Title,
                   UserId = userId,
               };

            this.NewsData.News.Add(newNewsItem);
            this.NewsData.SaveChanges();

            newsItemOutput.Id = newNewsItem.Id;
            return this.Created("DefaultApi", newsItemOutput);
        }

        // PUT api/news/5
        public IHttpActionResult Put(int id, [FromBody]NewsItemOutputModel newsItemOutput)
        {
            if (newsItemOutput == null)
            {
                this.ModelState.AddModelError("newsItem", "There is no news to change");
            }

            var newsItemForChange = this.NewsData.News.All().FirstOrDefault(n => n.Id == id);
            if (newsItemForChange == null)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            newsItemForChange.Content = newsItemOutput.Content;
            newsItemForChange.PublishDate = newsItemOutput.PublishDate;
            newsItemForChange.Title = newsItemOutput.Title;
            this.NewsData.SaveChanges();

            return this.Ok();
        }

        // DELETE api/news/5
        public IHttpActionResult Delete(int id)
        {
            var newsItemForChange = this.NewsData.News.All().FirstOrDefault(n => n.Id == id);
            if (newsItemForChange == null)
            {
                return this.NotFound();
            }

            this.NewsData.News.Delete(newsItemForChange);
            this.NewsData.SaveChanges();

            return this.Ok();
        }
    }
}
