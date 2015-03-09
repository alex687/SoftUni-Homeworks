SELECT e.EmployeeID, e.FirstName, e.LastName ,e.HireDate, d.Name
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE (d.Name = 'Sales' OR d.Name = 'Finance') AND DATEPART(year,e.HireDate) BETWEEN 1995 AND 2005