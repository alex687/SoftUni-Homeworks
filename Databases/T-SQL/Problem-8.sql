DECLARE towns CURSOR READ_ONLY FOR
	SELECT TownID, Name
	FROM Towns

OPEN towns

DECLARE 
	@townName nvarchar(max),
	@townId int,
	@firstEmployeeName nvarchar(max),
	@employeeName nvarchar(max);
FETCH NEXT FROM towns INTO @townId, @townName;

WHILE @@FETCH_STATUS = 0
BEGIN
	DECLARE employees CURSOR READ_ONLY FOR
		SELECT e.FirstName + ' ' + e.LastName
		FROM Employees e 
		JOIN Addresses a 
			ON a.AddressID = e.AddressID
		WHERE a.TownID = @townId
	OPEN employees;

	FETCH NEXT FROM employees INTO @firstEmployeeName;
	FETCH NEXT FROM employees INTO @employeeName;
	WHILE @@FETCH_STATUS = 0
	BEGIN 
		PRINT @townName + ': ' + @firstEmployeeName + ' ' + @employeeName
		FETCH NEXT FROM employees INTO @employeeName;
	END
	
	CLOSE employees
	DEALLOCATE employees
	
	FETCH NEXT FROM towns INTO @townId, @townName;
END

CLOSE towns
DEALLOCATE towns
GO