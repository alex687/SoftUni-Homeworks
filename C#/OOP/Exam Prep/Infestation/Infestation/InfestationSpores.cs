namespace Infestation
{
    class InfestationSpores : SupplementBase, ISupplement
    {
        private const int InfersAgression = 20;
        private const int InfesPower = -1;
        private const int InfesHealth = 0;

        public InfestationSpores()
            : base(InfestationSpores.InfesPower, InfestationSpores.InfesHealth, InfestationSpores.InfersAgression)
        {
            
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.AggressionEffect = 0;
                this.HealthEffect = 0;
                this.PowerEffect = 0;
            }
        }
    }
}
