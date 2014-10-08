namespace TheSlum.Items
{
    public class Axe : Item
    {
        private const int HealthDefaultEffect = 0;
        private const int DefenseDefaultEffect = 0;
        private const int AttackDefaultEffect = 75;

        public Axe(string id)
            : base(id, Axe.HealthDefaultEffect, Axe.DefenseDefaultEffect, Axe.AttackDefaultEffect)
        {
        }
    }
}
