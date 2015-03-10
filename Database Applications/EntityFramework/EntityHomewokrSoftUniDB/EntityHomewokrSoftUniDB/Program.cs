namespace EntityHomewokrSoftUniDB
{
    using System;
    using System.Linq;

    using EntityHomewokrSoftUniDB.SoftUniDB;

    public class Program
    {
        private static readonly SoftUniEntities Softuni = new SoftUniEntities();

        public static void Main(string[] args)
        {
            var employeesWithProjectAfter = FindEmployeesWithProjectStartAfterDate(2002);
            foreach (var employee in employeesWithProjectAfter)
            {
                Console.WriteLine(employee.FirstName + ' ' + employee.LastName);
            }

            var employeesWithProjectAfterNative = FindEmployeesWithProjectStartAfterDateNative(2002);
            foreach (var employee in employeesWithProjectAfterNative)
            {
                Console.WriteLine(employee.FirstName + ' ' + employee.LastName);
            }

            var employeesByDepartmentAndManager = FindEmployeesByDeparmentAndManager("Sales", Softuni.Employees.Find(273));
            foreach (var employee in employeesByDepartmentAndManager)
            {
                Console.WriteLine(employee.FirstName + ' ' + employee.LastName);
            }

            var employees = Softuni.Employees.Where(e => new[] { 1, 5, 22, 83 }.Contains(e.EmployeeID)).ToList();
            var newProject = new Project { Description = "Description Test", Employees = employees, StartDate = new DateTime(2014, 1, 2), Name = "Test" };
            InsertProject(newProject);

            var projects = Softuni.usp_getAllProjectsForEmployee("Guy", "Gilbert");
            foreach (var project in projects)
            {
                Console.WriteLine(project.Name + "---" + project.Description);
            }
        }

        private static IQueryable<Employee> FindEmployeesWithProjectStartAfterDate(int year)
        {
            return Softuni.Employees.Where(e => e.Projects.Any(p => p.StartDate.Year == year));
        }

        private static IQueryable<Employee> FindEmployeesWithProjectStartAfterDateNative(int year)
        {
            return Softuni.Employees.SqlQuery(
                      "SELECT e.* " +
                      "FROM dbo.Employees e " +
                      "WHERE  e.EmployeeID IN (SELECT ep.EmployeeID FROM dbo.Projects p JOIN dbo.EmployeesProjects ep ON p.ProjectID = ep.ProjectID WHERE YEAR(p.StartDate) = " + year.ToString() + ")")
                          .AsQueryable();
        }

        private static IQueryable<Employee> FindEmployeesByDeparmentAndManager(string departmentName, Employee manager)
        {
            return Softuni.Employees.Where(
                e => e.Department.Name == departmentName && e.ManagerID == manager.EmployeeID);
        }

        private static Project InsertProject(Project newProject)
        {
            var insertedProject = Softuni.Projects.Add(newProject);
            Softuni.SaveChanges();
            return insertedProject;
        }
    }
}
