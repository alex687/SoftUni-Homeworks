CREATE FUNCTION dbo.CalculateNewSum (@sum money, @yearlyInterestRate float, @numberMonths int)
RETURNS money
BEGIN
RETURN @Sum + @yearlyInterestRate  * (@numberMonths /12) * @sum
END

SELECT dbo.CalculateNewSum(100, 1, 12)
