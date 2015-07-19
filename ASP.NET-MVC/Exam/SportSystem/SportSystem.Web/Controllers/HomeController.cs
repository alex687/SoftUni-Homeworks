namespace SportSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using SportSystem.Data;
    using SportSystem.Web.ViewModels;
    using SportSystem.Web.ViewModels.MatchViewModels;
    using SportSystem.Web.ViewModels.TeamsViewModel;

    public class HomeController : BaseController
    {
        public HomeController(ISportSystemData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var topMatches = this.Data.Matches.All()
                .OrderByDescending(m => m.Bets.Count())
                .Take(3)
                .Project()
                .To<MatchViewModel>();

            var bestTeams = this.Data.Teams.All()
                .OrderByDescending(t => t.Votes.Sum(v => v.VoteValue))
                .Take(3)
                .Project()
                .To<TeamViewModel>();
          
            var model = new HomeViewModel { Matches = topMatches, Teams = bestTeams };
            return this.View(model);
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}