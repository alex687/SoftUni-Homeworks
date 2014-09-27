namespace Infestation
{
    class Parasite : InfestingUnit
    {
       private const int PHealth = 1;
       private const int PPower = 1;
       private const int PAggression = 1;

        public Parasite(string id)
            : base(id, UnitClassification.Biological, Parasite.PAggression, Parasite.PPower, Parasite.PHealth)
        {

        }
    }
}
