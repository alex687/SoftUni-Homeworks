namespace TheSlum.Items
{
    public class Shield : Item
    {
        private const int HealthDefaultEffect = 0;
        private const int DefenseDefaultEffect = 50;
        private const int AttackDefaultEffect = 0;

        public Shield(string id)
            : base(id, Shield.HealthDefaultEffect, Shield.DefenseDefaultEffect, Shield.AttackDefaultEffect)
        {
        }
    }
}
