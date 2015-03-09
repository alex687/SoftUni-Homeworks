INSERT INTO Users (Username, Password, FirstName, LastName)
	SELECT LOWER(FirstName + LastName) as Username, LOWER(FirstName + LastName) as Password , FirstName, LastName 
	FROM Employees