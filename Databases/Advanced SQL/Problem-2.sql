SELECT e.FirstName, e.LastName, e.Salary
FROM Employees e
WHERE e.Salary BETWEEN (SELECT MIN(Salary) FROM Employees) AND (SELECT MIN(Salary) FROM Employees)  * 1.1