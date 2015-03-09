SELECT AVG(e.Salary), MIN(d.Name) as Department
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.DepartmentID = 1 