namespace WarMachines.Pilots
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;

    class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
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
                    throw new ArgumentNullException("Pillot Name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            this.machines.Add(machine);
            machine.Pilot = this;
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.Append(this.Name + " - ");
            if (machines.Count == 0)
            {
                report.Append("no machines");
            }
            else
            {
                if (this.machines.Count == 1)
                {
                    report.Append(this.machines.Count + " machine" + Environment.NewLine);
                }
                else
                {
                    report.Append(this.machines.Count + " machines" + Environment.NewLine);
                }

                report.Append(string.Join(Environment.NewLine, this.machines));
            }
            return report.ToString();
        }
    }
}
