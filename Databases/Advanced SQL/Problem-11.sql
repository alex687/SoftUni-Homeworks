SELECT m.FirstName, m.LastName, COUNT(e.EmployeeID) as [Employees count]
FROM Employees e
JOIN Employees m ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING  COUNT(e.EmployeeID) = 5