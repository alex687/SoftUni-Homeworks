SELECT  t.Name as Town , COUNT(m.EmployeeID) as [Number of managers]
FROM (SELECT DISTINCT ManagerID FROM Employees WHERE ManagerID IS NOT NULL ) e
	JOIN Employees m ON  e.ManagerID  = m.EmployeeID
	JOIN Addresses a ON m.AddressID = a.AddressID
	JOIN Towns t ON a.TownID = t.TownID
	GROUP BY t.Name