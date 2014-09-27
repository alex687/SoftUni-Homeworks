namespace Infestation
{
    public class Queen : InfestingUnit
    {
        private const int QHealth = 30;
        private const int QPower = 1;
        private const int QAggression = 1;

        public Queen(string id)
            : base(id, UnitClassification.Psionic, Queen.QAggression, Queen.QPower, Queen.QHealth)
        {

        }
    }
}
