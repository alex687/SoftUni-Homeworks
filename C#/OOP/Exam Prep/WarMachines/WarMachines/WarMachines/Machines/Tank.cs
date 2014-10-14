namespace WarMachines.Machines
{
    using System;
    using Interfaces;

    class Tank : Machine, IMachine, ITank
    {
        private const double DefaultDefenceModeAddDefencePoints = 30;
        private const double DefaultDefenceModeRemoveAttackPoints = 40;
        private const double DefaultHealthPoints = 100;

        private bool defenseMode = false;
        private readonly double defenceModeOffAttackPoints;

        public Tank(string name, double attackPoints, double defencePoints, double healthPoints = Tank.DefaultHealthPoints)
            : base(name, attackPoints, defencePoints, healthPoints)
        {
            this.defenceModeOffAttackPoints = attackPoints;

            this.ToggleDefenseMode();
        }

        public bool DefenseMode
        {
            get
            {
                return this.defenseMode;
            }
        }

        public void ToggleDefenseMode()
        {
            this.defenseMode = !this.defenseMode;
            if (defenseMode)
            {
                this.DefensePoints += Tank.DefaultDefenceModeAddDefencePoints;
                if (this.AttackPoints < Tank.DefaultDefenceModeRemoveAttackPoints)
                {
                    this.AttackPoints = 0;
                }
                else
                {
                    this.AttackPoints -= Tank.DefaultDefenceModeRemoveAttackPoints;
                }
            }
            else
            {
                this.DefensePoints -= Tank.DefaultDefenceModeAddDefencePoints;
                this.AttackPoints = this.defenceModeOffAttackPoints;
            }

        }

        public override string ToString()
        {
            var defence = this.DefenseMode ? "ON" : "OFF";

            return "- " + this.Name + Environment.NewLine +
                " *Type: Tank" + Environment.NewLine +
                base.ToString() +
                " *Defense: " + defence;
        }
    }
}
