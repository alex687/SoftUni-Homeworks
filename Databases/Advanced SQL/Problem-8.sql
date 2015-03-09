SELECT  COUNT(e.EmployeeID) as [Employees without manager]
FROM Employees e
WHERE e.ManagerID IS NULL