namespace Infestation
{
    class SupplementBase : ISupplement
    {
        public SupplementBase(int power, int health, int aggression)
        {
            this.PowerEffect = power;
            this.AggressionEffect = aggression;
            this.HealthEffect = health;
        }

        public int PowerEffect { get; protected set; }

        public int HealthEffect { get; protected set; }

        public int AggressionEffect { get; protected set; }

        public virtual void ReactTo(ISupplement otherSupplement)
        {
        }
    }
}
