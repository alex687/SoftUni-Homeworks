SELECT TOP(1) t.Name as Town , COUNT(e.EmployeeID) as [Number of employees]
FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY [Number of employees] DESC