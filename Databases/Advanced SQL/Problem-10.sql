SELECT t.Name as Town, d.Name as Department, COUNT(e.EmployeeID) as [Employees count]
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON a.TownID = t.TownID
GROUP BY t.Name, d.Name