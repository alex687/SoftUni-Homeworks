namespace Infestation
{
    using System.Collections.Generic;
    using System.Linq;

    public class InfestingUnit : Unit
    {
        public InfestingUnit(string id, UnitClassification classification, int aggression, int power , int health)
            : base(id, classification, health, power, aggression)
        {
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where((unit) => this.CanAttackUnit(unit));

            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);

            if (optimalAttackableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            if (this.Id != unit.Id && InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification).Equals(this.UnitClassification))
            {
                return true;
            }
            return false;
        }

        protected override UnitInfo GetOptimalAttackableUnit(System.Collections.Generic.IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, int.MaxValue, 0, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Health < optimalAttackableUnit.Health)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }

    }
}
