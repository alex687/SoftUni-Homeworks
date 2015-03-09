CREATE PROCEDURE usp_WithdrawMoney
	@accountId int,
	@money money
AS 
	DECLARE @oldBalance  money; 
	SELECT @oldBalance = Balance FROM Accounts WHERE Id = @accountId
	IF(@oldBalance < @money)
	BEGIN		
		RAISERROR('Not enough money', 16, 1);
	END
	ELSE
	BEGIN
		UPDATE Accounts SET Balance = @oldBalance - @money WHERE Id = @accountId
	END
GO

EXEC usp_WithdrawMoney 1, 50

CREATE PROCEDURE usp_DepositMoney
	@accountId int,
	@money money
AS 
	UPDATE Accounts SET Balance = Balance + @money WHERE Id = @accountId

GO

EXEC usp_DepositMoney 1, 50


