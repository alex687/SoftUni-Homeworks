SELECT e.FirstName +' '+ e.LastName  as [Employee Name], ISNULL(m.FirstName + ' ' + m.LastName, 'No manager') as [Managers Name]
FROM Employees e
LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID