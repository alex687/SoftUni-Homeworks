SELECT d.Name, e.JobTitle, AVG(e.Salary) as [AVG salary]
FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle