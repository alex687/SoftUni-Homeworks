SELECT e.EmployeeID, e.FirstName, e.LastName , m.EmployeeID, m.FirstName, m.LastName
FROM Employees e
LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID


SELECT m.EmployeeID, m.FirstName, m.LastName , e.EmployeeID, e.FirstName, e.LastName
FROM Employees e
RIGHT JOIN Employees m ON m.ManagerID = e.EmployeeID
