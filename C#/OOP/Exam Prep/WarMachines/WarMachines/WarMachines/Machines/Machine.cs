namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;

    class Machine : IMachine, IComparable<Machine>
    {
        private string name;
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defencePoints;
        private IList<string> targers;

        public Machine(string name, double attackPoints, double defencePoints, double healthPoints)
        {
            this.Name = name;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defencePoints;
            targers = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;

            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;

            }

            set
            {
                this.pilot = value;

            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;

            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Health points cannot be less than 0");
                }

                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Attack points cannot be less than 0");
                }

                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get
            {
                return this.defencePoints;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Defence points cannot be less than 0");
                }

                this.defencePoints = value;
            }
        }

        public IList<string> Targets
        {
            get
            {
                return this.targers;
            }
        }

        public void Attack(string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                throw new ArgumentNullException("Target cannot be null or empty");
            }

            this.targers.Add(target);
        }

        public int CompareTo(Machine other)
        {
            var healthCompare = this.healthPoints.CompareTo(other.HealthPoints);

            if (healthCompare == 0)
            {
                return this.name.CompareTo(other.Name);
            }

            return healthCompare;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(" *Health: " + this.healthPoints + Environment.NewLine);
            str.Append(" *Attack: " + this.attackPoints + Environment.NewLine);
            str.Append(" *Defense: " + this.defencePoints + Environment.NewLine);

            str.Append(" *Targets: ");
            if (this.targers.Count == 0)
            {
                str.Append("None");
            }
            else
            {
               str.Append(string.Join(", ", this.targers));
            }
            str.Append(Environment.NewLine);
  
            return str.ToString();
        }
    }
}
