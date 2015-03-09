CREATE PROCEDURE usp_GetAllPersonsWhoHaveMoreMoneyThan
	@money money
AS 
	SELECT p.*
	FROM Persons p
	JOIN Accounts a ON a.PersonId = p.Id
	WHERE a.Balance > @money
GO

EXEC usp_GetAllPersonsWhoHaveMoreMoneyThan 1


