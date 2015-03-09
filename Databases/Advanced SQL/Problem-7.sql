SELECT  COUNT(e.EmployeeID) as [Employees with manager]
FROM Employees e
WHERE e.ManagerID IS NOT NULL