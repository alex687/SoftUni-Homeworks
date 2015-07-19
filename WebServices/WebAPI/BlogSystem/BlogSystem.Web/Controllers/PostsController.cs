namespace BlogSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using BlogSystem.Data;
    using BlogSystem.Models;
    using BlogSystem.Web.Models.Posts;
    using BlogSystem.Web.Models.Tags;

    using Microsoft.AspNet.Identity;

    [Authorize]
    public class PostsController : ApiController
    {
        private IBlogSystemData data;

        public PostsController(IBlogSystemData data)
        {
            this.data = data;
        }

        [AllowAnonymous]
        public IHttpActionResult GetAll()
        {
            var posts = this.data.Posts.All().Project().To<PostViewModel>();
            return this.Ok(posts);
        }

        [AllowAnonymous]
        public IHttpActionResult Get(int id)
        {
            var post = this.data.Posts.All().FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return this.NotFound();
            }

            var mappedPost = Mapper.Map<PostViewModel>(post);
            return this.Ok(mappedPost);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody]PostUploadModel newPostModel)
        {
            if (newPostModel == null)
            {
                this.ModelState.AddModelError("post", "There is no post");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            // ReSharper disable once PossibleNullReferenceException
            newPostModel.UserId = this.User.Identity.GetUserId();

            var post = Mapper.Map<Post>(newPostModel);
            post.Tags = this.GetOrCreateTags(newPostModel.Tags);

            this.data.Posts.Add(post);
            this.data.SaveChanges();
            this.data.Posts.Detach(post);

            newPostModel.Id = post.Id;
            return this.Ok(newPostModel);
        }

        [HttpPut]
        public IHttpActionResult Edit(int id, [FromBody]PostUploadModel newPostModel)
        {
            var post = this.data.Posts.All().Where(p => p.Id == id).Select(p => new { p.Id, p.UserId }).FirstOrDefault();
            if (post == null)
            {
                return this.NotFound();
            }

            if (newPostModel == null)
            {
                this.ModelState.AddModelError("post", "There is no post uploaded");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var postUpdate = Mapper.Map<Post>(newPostModel);
            postUpdate.Id = post.Id;
            postUpdate.UserId = post.UserId;
            // ReSharper disable once PossibleNullReferenceException
            postUpdate.Tags = this.GetOrCreateTags(newPostModel.Tags);

            this.data.Posts.Update(postUpdate);
            this.data.SaveChanges();
            this.data.Posts.Detach(postUpdate);

            return this.Ok(newPostModel);
        }

        public IHttpActionResult Delete(int id)
        {
            var post = this.data.Posts.All().FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return this.NotFound();
            }

            this.data.Posts.Delete(post);

            return this.Ok();
        }

        private HashSet<Tag> GetOrCreateTags(IEnumerable<TagUploadModel> uploadedTags)
        {
            var tags = new HashSet<Tag>();
            foreach (var uploadedTag in uploadedTags)
            {
                var tag = this.data.Tags.All().FirstOrDefault(t => t.Name == uploadedTag.Name);
                if (tag == null)
                {
                    tag = new Tag() { Name = uploadedTag.Name };
                    this.data.Tags.Add(tag);
                    this.data.SaveChanges();
                }

                tags.Add(tag);
            }

            return tags;
        }
    }
}
