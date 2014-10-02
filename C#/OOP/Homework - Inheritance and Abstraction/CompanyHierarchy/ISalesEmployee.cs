namespace CompanyHierarchy
{
    using System.Collections.Generic;

    public interface ISalesEmployee : IEmployee
    {
        IList<ISale> Sales { get; set; }
    }
}