namespace SportSystem.Web.ViewModels
{
    using System.Collections.Generic;

    using SportSystem.Web.ViewModels.MatchViewModels;
    using SportSystem.Web.ViewModels.TeamsViewModel;

    public class HomeViewModel
    {
        public IEnumerable<MatchViewModel> Matches { get; set; }
        
        public IEnumerable<TeamViewModel> Teams { get; set; }
    }
}