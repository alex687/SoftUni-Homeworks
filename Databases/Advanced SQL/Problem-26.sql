SELECT d.Name, e.JobTitle, MIN(e.Salary) as [min salary]
FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle