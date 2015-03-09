SELECT e.EmployeeID, e.FirstName, e.LastName , m.EmployeeID, m.FirstName, m.LastName
FROM Employees e
JOIN Employees m ON e.ManagerID = m.EmployeeID
