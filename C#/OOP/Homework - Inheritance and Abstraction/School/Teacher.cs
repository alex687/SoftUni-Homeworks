
namespace School
{
    using System;
    using System.Collections.Generic;

    public class Teacher : NamebleAndDetailsEntity
    {
        private ICollection<Discipline> disciplines;

        public Teacher(string name, ICollection<Discipline> disciplines)
            : base(name)
        {
            this.Disciplines = disciplines;
        }

        public Teacher(string name, ICollection<Discipline> disciplines, string details)
            : this(name, disciplines)
        {
            this.Details = details;
        }

        public ICollection<Discipline> Disciplines
        {
            get { return this.disciplines; }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentNullException("No disciplines");
                }

                this.disciplines = value;
            }
        }
    }
}
