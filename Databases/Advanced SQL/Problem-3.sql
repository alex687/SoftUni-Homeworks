SELECT e.FirstName +' '  + e.LastName as FullName, e.Salary, d.Name as Department
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = (SELECT MIN(Salary) FROM Employees WHERE DepartmentID = d.DepartmentID)