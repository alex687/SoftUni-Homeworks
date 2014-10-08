namespace TheSlum.Bonuses
{
    public class Injection : Bonus
    {
        private const int HealthDefaultEffect = 200;
        private const int DefenseDefaultEffect = 0;
        private const int AttackDefaultEffect = 0;
        private const int CountdownDefaultTurns = 3;

        public Injection(string id)
            : base(id, Injection.HealthDefaultEffect, Injection.DefenseDefaultEffect, Injection.AttackDefaultEffect)
        {
            this.Countdown = Injection.CountdownDefaultTurns;
        }
    }
}
