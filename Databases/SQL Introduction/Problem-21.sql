SELECT e.EmployeeID, e.FirstName, e.LastName, a.AddressText, m.EmployeeID, m.FirstName, m.LastName
FROM Employees e
JOIN Employees m ON e.ManagerID = m.EmployeeID
JOIN Addresses a ON a.AddressID = e.AddressID