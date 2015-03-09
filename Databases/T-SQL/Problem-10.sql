DECLARE towns CURSOR READ_ONLY FOR
	SELECT TownID, Name
	FROM Towns

OPEN towns

DECLARE 
	@townName nvarchar(max),
	@townId int,
	@employeeNames nvarchar(max);
FETCH NEXT FROM towns INTO @townId, @townName;

WHILE @@FETCH_STATUS = 0
BEGIN
	
	SELECT	 @employeeNames = dbo.[Concatenate](FirstName + ' ' + LastName)
	FROM Employees e
	JOIN Addresses a  ON e.AddressID = a.AddressID
	WHERE a.TownID = @townId
	
	PRINT @townName + ' -> ' + @employeeNames;

	FETCH NEXT FROM towns INTO @townId, @townName;
END

CLOSE towns
DEALLOCATE towns
GO