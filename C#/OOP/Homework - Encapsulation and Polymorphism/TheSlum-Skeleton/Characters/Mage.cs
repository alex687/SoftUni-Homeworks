namespace TheSlum.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class Mage : AttackCharacter, IAttack
    {
        private const int HealthDefaultPoints = 150;
        private const int DefenseDefaultPoints = 50;
        private const int AttackDefaultPoints = 300;
        private const int RangeDefault = 5;

        public Mage(string id, int x, int y, Team team)
            : base(id, x, y, Mage.HealthDefaultPoints, Mage.DefenseDefaultPoints, team, Mage.RangeDefault)
        {
            this.AttackPoints = Mage.AttackDefaultPoints;
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.Where(c => c.Team != this.Team).LastOrDefault(c => c.IsAlive);
        }
    }
}
