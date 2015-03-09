USE SoftUni
GO

--Enabling CLR Integration
sp_configure 'clr enabled', 1;
GO
RECONFIGURE;
GO

IF OBJECT_ID(N'Concatenate', N'AF') is not null
DROP Aggregate Concatenate;
GO

IF EXISTS (SELECT * FROM sys.assemblies WHERE [name] = 'StringUtils')
DROP ASSEMBLY StringUtils;
GO

DECLARE @SamplePath nvarchar(1024)
-- You will need to modify the value of the this variable if you have installed the sample someplace other than the default location.
Set @SamplePath = 'C:\dll\'
CREATE ASSEMBLY [StringUtils] 
FROM @SamplePath + 'StringUtils.dll'
WITH permission_set = Safe;
GO

CREATE AGGREGATE [dbo].[Concatenate](@input nvarchar(max))
RETURNS nvarchar(max)
EXTERNAL NAME [StringUtils].[Concatenate];
GO


SELECT dbo.[Concatenate](FirstName + ' ' + LastName)
FROM Employees
