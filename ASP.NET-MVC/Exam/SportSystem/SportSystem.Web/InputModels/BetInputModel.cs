namespace SportSystem.Web.InputModels
{
    using SportSystem.Models;
    using SportSystem.Web.Infrastructure.Mappings;

    public class BetInputModel : IMapTo<Bet>
    {
        public int Ammount { get; set; }
    }
}