namespace BugTracker.RestServices.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using AutoMapper.QueryableExtensions;

    using BugTracker.Data;
    using BugTracker.Data.Models;
    using BugTracker.RestServices.Models.Bugs;

    using Microsoft.AspNet.Identity;

    public class BugsController : BaseController
    {
        public BugsController()
            : base()
        {
        }

        public BugsController(IBugTrackerData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetAllBugs()
        {
            var bugs = this.Data.Bugs.All().OrderByDescending(b => b.DateCreated).Project().To<BugMinOutputModel>();

            return this.Ok(bugs);
        }

        [HttpGet]
        public IHttpActionResult GetBug(int id)
        {
            var bug = this.Data.Bugs.All().Where(b => b.Id == id).Project().To<BugOutputModel>().FirstOrDefault();

            if (bug == null)
            {
                return this.NotFound();
            }

            //TODO : Can't find a better solution 
            bug.Comments = bug.Comments.OrderByDescending(c => c.DateCreated).ToList();

            return this.Ok(bug);
        }

        [HttpPost]
        public IHttpActionResult PostCreateBug(BugBindingCreateBugModel bugData)
        {
            if (bugData == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }


            var bug = new Bug() { Title = bugData.Title, Description = bugData.Description, DateCreated = DateTime.Now };
            if (this.User.Identity.IsAuthenticated)
            {
                bug.AuthorId = this.User.Identity.GetUserId();
            }

            this.Data.Bugs.Add(bug);
            this.Data.SaveChanges();

            if (this.User.Identity.IsAuthenticated)
            {
                return this.CreatedAtRoute("DefaultApi", new { id = bug.Id }, new { Id = bug.Id, Author = this.User.Identity.GetUserName(), Message = "User bug submitted." });
            }

            return this.CreatedAtRoute("DefaultApi", new { id = bug.Id }, new { Id = bug.Id, Message = "Anonymous bug submitted." });
        }

        [HttpPatch]
        public IHttpActionResult PatchEditBug(int id, BugBindingEditBugModel bugData)
        {
            var bug = this.Data.Bugs.All().FirstOrDefault(b => b.Id == id);
            if (bug == null)
            {
                return this.NotFound();
            }

            if (bugData == null)
            {
                return this.BadRequest();
            }

            if (bugData.Title != null)
            {
                bug.Title = bugData.Title;
            }

            if (bugData.Description != null)
            {
                bug.Description = bugData.Description;
            }

            if (bugData.Status != null)
            {
                Status status;
                if (Enum.TryParse<Status>(bugData.Status, false, out status))
                {
                    bug.Status = (Status)status;
                }
                else
                {
                    return this.BadRequest();
                }
            }

            this.Data.SaveChanges();

            return this.Ok(new { Message = "Bug #" + bug.Id + " patched." });
        }

        [HttpDelete]
        public IHttpActionResult DeleteBug(int id)
        {
            Bug bug = this.Data.Bugs.All().FirstOrDefault(b => b.Id == id);
            if (bug == null)
            {
                return this.NotFound();
            }

            this.Data.Bugs.Delete(bug);
            this.Data.SaveChanges();

            return this.Ok(new { Message = "Bug #" + id + " deleted." });
        }


        [HttpGet]
        [Route("api/bugs/filter")]
        public IHttpActionResult GetFilterBugs(string keyword = null, string statuses = null, string author = null)
        {
            var bugsQuery = this.Data.Bugs.All().AsQueryable();
            if (keyword != null)
            {
                bugsQuery = bugsQuery.Where(b => b.Title.Contains(keyword));
            }

            if (statuses != null)
            {
                var statusesArr = new HashSet<Status>();
                foreach (var statusStr in statuses.Split('|'))
                {
                    Status status;
                    if (Enum.TryParse<Status>(statusStr, false, out status))
                    {
                        statusesArr.Add(status);
                    }
                }

                bugsQuery = bugsQuery.Where(b => statusesArr.Contains(b.Status));
            }


            if (author != null)
            {
                bugsQuery = bugsQuery.Where(b => b.Author.UserName == author);
            }

            var bugs = bugsQuery.OrderByDescending(b => b.DateCreated).Project().To<BugMinOutputModel>();

            return this.Ok(bugs);
        }
    }
}
