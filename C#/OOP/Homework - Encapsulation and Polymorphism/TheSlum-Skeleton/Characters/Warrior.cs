namespace TheSlum.Characters
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class Warrior : AttackCharacter, IAttack
    {
        private const int HealthDefaultPoints = 200;
        private const int DefenseDefaultPoints = 100;
        private const int AttackDefaultPoints = 150;
        private const int RangeDefault = 2;

        public Warrior(string id, int x, int y, Team team)
            : base(id, x, y, Warrior.HealthDefaultPoints, Warrior.DefenseDefaultPoints, team, Warrior.RangeDefault)
        {
            this.AttackPoints = Warrior.AttackDefaultPoints;
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.Where(c => c.Team != this.Team).FirstOrDefault(c => c.IsAlive);
        }
    }
}
