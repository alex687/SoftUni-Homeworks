BEGIN TRANSACTION;
 
DELETE EmployeesProjects FROM Employees e
 JOIN Departments d ON e.EmployeeID = d.DepartmentID
 JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
WHERE d.Name = 'Sales';

ALTER TABLE Employees
NOCHECK CONSTRAINT FK_Employees_Departments

-- The Department must be deleted because there is no Manager 
DELETE Departments
WHERE Name = 'Sales';

DELETE Employees FROM Employees e
 JOIN Departments d
 ON e.EmployeeID = d.DepartmentID
WHERE d.Name = 'Sales';
 
ROLLBACK TRAN;