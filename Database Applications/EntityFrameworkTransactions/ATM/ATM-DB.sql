USE [master]
GO

CREATE DATABASE [ATM]
GO

USE ATM
GO

CREATE TABLE CardAccounts(
	Id int PRIMARY KEY IDENTITY,
	CardNumber char(10) UNIQUE NOT NULL,
	CardPIN char(4) NOT NULL,
	CardCash money NOT NULL
)
GO

INSERT INTO CardAccounts(CardNumber, CardPIN, CardCash)
VALUES('7894789512', '1234', 10000),
	('7894787426', '1111', 100)

GO

USE ATM
GO

CREATE TABLE TransactionHistory(
	Id int IDENTITY PRIMARY KEY,
	CardNumber nvarchar(10) NOT NULL,
	TransactionDate datetime2 NOT NULL,
	Amount money NOT NULL
)