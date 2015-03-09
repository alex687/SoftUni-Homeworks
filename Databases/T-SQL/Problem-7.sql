USE SoftUni
GO

--Enabling CLR Integration
sp_configure 'clr enabled', 1;
GO
RECONFIGURE;
GO

IF OBJECT_ID(N'RegexLike', N'FS') is not null
DROP FUNCTION RegexLike;
GO

IF EXISTS (SELECT * FROM sys.assemblies WHERE [name] = 'SqlRegularExpression')
DROP ASSEMBLY SqlRegularExpression;
GO

DECLARE @SqlRegularExpressionLocation nvarchar(1024)
-- SET THE LOCATION OF THE StringUtils.dll FILE !!!!!
Set @SqlRegularExpressionLocation = 'C:\dll\'
CREATE ASSEMBLY [SqlRegularExpression] 
FROM @SqlRegularExpressionLocation + 'SqlRegularExpressions.dll'
WITH permission_set = Safe;
GO

CREATE FUNCTION  RegexLike(@text nvarchar(max), @pattern nvarchar(max))
RETURNS BIT AS EXTERNAL NAME SqlRegularExpression.SqlRegularExpressions.[Like]
GO

IF OBJECT_ID(N'udf_AllPatternMatchingNames', N'TF') is not null
DROP FUNCTION udf_AllPatternMatchingNames;
GO

CREATE FUNCTION udf_AllPatternMatchingNames(@pattern nvarchar(255))
    RETURNS @MatchedNames TABLE ( Name varchar(50) )
AS
BEGIN
    INSERT @MatchedNames
    SELECT * FROM 
        (SELECT e.FirstName FROM Employees e
        UNION
        SELECT e.LastName FROM Employees e
        UNION 
        SELECT t.Name FROM Towns t) as temp(Name)
    WHERE 1 = dbo.RegexLike(LOWER(Name), @pattern)
    RETURN
END
GO

SELECT * FROM  dbo.udf_AllPatternMatchingNames( '^[oistmiahf]+$')
