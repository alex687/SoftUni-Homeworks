SELECT  COUNT(e.EmployeeID) as [Sales Employees Count]
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'