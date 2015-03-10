namespace EntityHomewokrSoftUniDB.DAO
{
    using EntityHomewokrSoftUniDB.SoftUniDB;

    public class EmployeeDao
    {
        private static readonly SoftUniEntities SoftUni = new SoftUniEntities();

        public static int Insert(Employee e)
        {
            SoftUni.Employees.Add(e);
            SoftUni.SaveChanges();

            return e.EmployeeID;
        }

        public static void Delete(Employee e)
        {
            SoftUni.Employees.Remove(e);
            SoftUni.SaveChanges();
        }

        public static void Update(int employeeId, string propertyNameToUpdate, object newValue)
        {
            var employee = SoftUni.Employees.Find(employeeId);

            if (employee != null)
            {
                employee.GetType().GetProperty(propertyNameToUpdate).SetValue(employee, newValue);
            }
        }
    }
}