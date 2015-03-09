CREATE PROCEDURE usp_CalculateNewBalance
	@accountId int,
	@yearlyInterestRate float
AS 
	DECLARE @oldBalance money, @personId int;
	SELECT @oldBalance = Balance, @personId = PersonId FROM Accounts WHERE Id = @accountId

	SELECT p.* , @oldBalance as OldBalance, dbo.ufn_CalculateNewSum(@oldBalance, @yearlyInterestRate, 1) as NewBalance
	FROM Persons p
	WHERE Id = @personId
GO

EXEC usp_CalculateNewBalance 1, 0.5


