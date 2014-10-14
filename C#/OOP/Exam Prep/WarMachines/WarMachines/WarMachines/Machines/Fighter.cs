namespace WarMachines.Machines
{
    using System;
    using Interfaces;

    class Fighter : Machine, IMachine, IFighter
    {
        private const double DefaultHealthPoints = 200;

        private bool stealthMode = false;

        public Fighter(string name, double attackPoints, double defencePoints, bool stealthMode, double healthPoints = Fighter.DefaultHealthPoints)
            : base(name, attackPoints, defencePoints, healthPoints)
        {
            this.stealthMode = stealthMode;
        }

        public bool StealthMode
        {
            get
            {
                return this.stealthMode;
            }
        }

        public void ToggleStealthMode()
        {
            this.stealthMode = !this.stealthMode;
        }

        public override string ToString()
        {
            var stealth = this.stealthMode ? "ON" : "OFF";

            return "- " + this.Name + Environment.NewLine +
                " *Type: Fighter" + Environment.NewLine +
                base.ToString() +
                " *Stealth: " + stealth;
        }
    }
}
