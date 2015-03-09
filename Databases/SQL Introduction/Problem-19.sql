SELECT EmployeeID, FirstName, LastName , AddressText
FROM Employees e, Addresses a 
 WHERE e.AddressID = a.AddressID
