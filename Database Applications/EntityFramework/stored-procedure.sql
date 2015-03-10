CREATE PROCEDURE usp_getAllProjectsForEmployee 
    @FirstName nvarchar(50),
    @LastName nvarchar(50)
AS 

   SELECT p.*
   FROM Employees e
   JOIN dbo.EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
   JOIN dbo.Projects p ON p.ProjectID = ep.ProjectID
   WHERE e.FirstName = @FirstName AND e.LastName = @LastName
GO