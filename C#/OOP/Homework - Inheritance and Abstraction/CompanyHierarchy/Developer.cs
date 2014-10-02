namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;

    public class Developer : Employee, IDeveloper
    {
        private IList<IProject> projects;

        public Developer(string id, string firstName, string lastName, decimal salary, Department department, IList<IProject> projects)
            : base(id, firstName, lastName, salary, department)
        {
            this.Projects = projects;
        }

        public IList<IProject> Projects
        {
            get
            {
                return this.projects;
            }

            set
            {
                if (null == value)
                {
                    throw new ArgumentNullException("Projects", "Projects can not be null!");
                }

                this.projects = value;
            }
        }
        public override string ToString()
        {
            string baseStr = base.ToString();
            return baseStr + string.Format("\nProjects: ", string.Join("\n", this.Projects));
        }
    }
}