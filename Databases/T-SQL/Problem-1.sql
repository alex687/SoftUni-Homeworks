ALTER PROCEDURE usp_GetFullNameOfPersons  
AS 
	SELECT FirstName + ' ' + LastName as FullName
	FROM Persons
GO

EXEC usp_GetFullNameOfPersons


