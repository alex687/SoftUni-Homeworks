namespace TheSlum.Characters
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    
    public class Healer : Character, IHeal
    {
        private const int HealthDefaultPoints = 75;
        private const int DefenseDefaultPoints = 50;
        private const int HealingDefaultPoints = 60;
        private const int RangeDefault = 6;

        public Healer(string id, int x, int y, Team team) 
            : base(id, x, y, Healer.HealthDefaultPoints, Healer.DefenseDefaultPoints, team, Healer.RangeDefault)
        {
            this.HealingPoints = Healer.HealingDefaultPoints;
        }

        public int HealingPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var min = targetsList.Where(c => c.Team == this.Team && c != this).Min(c => c.HealthPoints);
            
            return targetsList.FirstOrDefault(c => c.HealthPoints == min);
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            this.RemoveItemEffects(item);
        }
    }
}
