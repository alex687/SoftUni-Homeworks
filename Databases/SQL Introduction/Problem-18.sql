SELECT EmployeeID, FirstName, LastName , AddressText
FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
