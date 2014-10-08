namespace TheSlum.Bonuses
{
    public class Pill : Bonus
    {
        private const int HealthDefaultEffect = 0;
        private const int DefenseDefaultEffect = 0;
        private const int AttackDefaultEffect = 100;
        private const int CountdownDefaultTurns = 1;

        public Pill(string id)
            : base(id, Pill.HealthDefaultEffect, Pill.DefenseDefaultEffect, Pill.AttackDefaultEffect)
        {
            this.Countdown = Pill.CountdownDefaultTurns;
        }
    }
}
