namespace SportSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using PagedList;

    using SportSystem.Data;
    using SportSystem.Models;
    using SportSystem.Web.InputModels;
    using SportSystem.Web.ViewModels.TeamsViewModel;

    [Authorize]
    public class TeamsController : BaseController
    {
        public TeamsController(ISportSystemData data)
            : base(data)
        {
        }

        [AllowAnonymous]
        public ActionResult Index(int page = 1)
        {
            var teams = this.Data.Teams.All().OrderByDescending(m => m.Id)
            .Project()
            .To<TeamViewModel>();

            PagedList<TeamViewModel> model = new PagedList<TeamViewModel>(teams, page, 4);

            return this.View(model);
        }

        public ActionResult Details(int id)
        {
            var teamViewModel = this.Data.Teams.All().Where(m => m.Id == id).Project().To<TeamViewDetailsModel>().FirstOrDefault();
            if (teamViewModel == null)
            {
                return this.HttpNotFound();
            }

            if (this.Data.Votes.All().FirstOrDefault(v => v.UserId == this.UserProfille.Id && v.TeamId == id) != null)
            {
                teamViewModel.IsVoted = true;
            }

            return this.View(teamViewModel);
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamInputModel teamInput)
        {
            if (teamInput != null && this.ModelState.IsValid)
            {
                var team = Mapper.Map<Team>(teamInput);
                this.Data.Teams.Add(team);

                this.Data.Players.All().Where(p => teamInput.Players.Contains(p.Id))
                    .Each(p => team.Players.Add(p));

                this.Data.SaveChanges();

                return this.RedirectToAction("Details", "Teams", new { id = team.Id });
            }

            return this.View(teamInput);
        }

        public ActionResult AddPlayer()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            var players =
                this.Data.Players.All()
                    .Where(p => p.TeamId == null)
                    .Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() })
                    .ToList();

            return this.PartialView("_AddPlayer", players);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(Team team)
        {
            var vote = new Vote { TeamId = team.Id, UserId = this.UserProfille.Id, VoteValue = 1 };
            this.Data.Votes.Add(vote);
            this.Data.SaveChanges();

            return this.Content(team.Votes.Sum(v => v.VoteValue).ToString());
        }
    }
}