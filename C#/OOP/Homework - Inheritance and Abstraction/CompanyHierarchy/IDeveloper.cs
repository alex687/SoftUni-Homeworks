namespace CompanyHierarchy
{
    using System.Collections.Generic;

    public interface IDeveloper : IEmployee
    {
        IList<IProject> Projects { get; set; }
    }
}