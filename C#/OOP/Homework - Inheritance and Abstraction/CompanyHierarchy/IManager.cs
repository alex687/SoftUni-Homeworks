namespace CompanyHierarchy
{
    using System.Collections.Generic;

    public interface IManager : IEmployee
    {
        ICollection<IEmployee> Employees { get; set; }
    }
}