namespace Bookmarks.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Bookmarks.Areas.Admin.Models.View;
    using Bookmarks.Data;
    using Bookmarks.Models;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public class CategoriesController : BaseAdminController
    {

        public CategoriesController(IBookmarksData data)
            : base(data)
        {
        }

        // GET: Admin/Categories
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var categories = this.Data.Categories
                .All()
                .Project()
                .To<CategoryModel>();
            return this.Json(categories.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, CategoryModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var category = Mapper.Map<Category>(model);
                this.Data.Categories.Add(category);
                this.Data.SaveChanges();

                model.Id = category.Id;
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, CategoryModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var category = this.Data.Categories.All().FirstOrDefault(x => x.Id == model.Id);
                if (category != null)
                {
                    category.Name = model.Name;
                }

                this.Data.Categories.Update(category);
                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Delete([DataSourceRequest]DataSourceRequest request, CategoryModel model)
        {
            this.Data.Categories.Delete(model.Id);
            this.Data.SaveChanges();

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}