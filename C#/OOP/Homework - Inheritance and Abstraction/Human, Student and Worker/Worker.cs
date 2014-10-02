namespace HumanStudentWorker
{
    using System;

    public class Worker : Human
    {
        private decimal weekSalary;
        private float workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, float workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public float WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Work Hours Per Day must be > 0");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Week Salay must be > 0");
                }

                this.weekSalary = value;
            }
        }

        public decimal MoneyPerHour(int daysPerWeek)
        {
            return this.WeekSalary / (decimal)(daysPerWeek * this.WorkHoursPerDay);
        }
    }
}
