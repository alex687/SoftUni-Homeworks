namespace SportSystem.Web.Controllers
{
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using PagedList;

    using SportSystem.Data;
    using SportSystem.Models;
    using SportSystem.Web.InputModels;
    using SportSystem.Web.ViewModels.MatchViewModels;

    [Authorize]
    public class MatchesController : BaseController
    {
        public MatchesController(ISportSystemData data)
            : base(data)
        {
        }

        [AllowAnonymous]
        public ActionResult Index(int page = 1)
        {
            var matches = this.Data.Matches.All().OrderBy(m => m.StartDate)
            .Project()
            .To<MatchViewModel>();

            PagedList<MatchViewModel> model = new PagedList<MatchViewModel>(matches, page, 4);

            return this.View(model);
        }

        public ActionResult Details(int id)
        {
            var matchViewModel = this.Data.Matches.All().Where(m => m.Id == id).Project().To<MatchViewDetailsModel>().FirstOrDefault();
            if (matchViewModel == null)
            {
                return this.HttpNotFound();
            }

            return this.View(matchViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBet(SportSystem.Models.Match match, int teamId, BetInputModel betInput)
        {
            if (match == null)
            {
                return this.HttpNotFound();
            }

            if (match.HomeTeamId != teamId && match.AwayTeamId != teamId)
            {
                return this.HttpNotFound();
            }

            var bet = Mapper.Map<Bet>(betInput);
            bet.UserId = this.UserProfille.Id;
            bet.TeamId = teamId;
            bet.MatchId = match.Id;
            this.Data.Bets.Add(bet);

            this.Data.SaveChanges();

            var newAmmount = this.Data.Bets.All().Where(b => b.TeamId == teamId && b.MatchId == match.Id).Sum(b => b.Ammount);

            return this.Content(newAmmount.ToString(CultureInfo.InvariantCulture));
        }
    }
}