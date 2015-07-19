namespace ForumSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using ForumSystem.Data;

    [Authorize]
    public class ArticleController : BaseController
    {
        public ArticleController()
            : base()
        {
        }

        public ArticleController(ApplicationDbContext data)
            : base(data)
        {
        }

        public IHttpActionResult Get([FromUri] string category = null, [FromUri] int page = 0)
        {
            var articlesQuery = this.Data.Articles.AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                articlesQuery = articlesQuery.Where(a => a.Category.Name == category);
            }

            int numberArticles = page * NumberArticlesPerPage;
            var articles = articlesQuery.Skip(numberArticles).Take(NumberArticlesPerPage);

            return this.Ok(articles);
        }

        public IHttpActionResult Get(int id)
        {
            var article = this.Data.Articles.FirstOrDefault(a => a.Id == id);

            if (article == null)
            {
                return this.NotFound();
            }

            return this.Ok(article);
        }

        public void Post([FromBody]string value)
        {
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
