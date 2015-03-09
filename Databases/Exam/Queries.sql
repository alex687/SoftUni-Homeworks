SELECT p.PeakName
FROM dbo.Peaks p
ORDER BY p.PeakName
-----------------------------------------------

SELECT TOP 30 c.CountryName, c.Population
FROM dbo.Countries c
JOIN dbo.Continents c2 ON c2.ContinentCode = c.ContinentCode
WHERE c2.ContinentName = 'Europe'
ORDER BY c.Population DESC
-------------------------------------------------

SELECT c.CountryName, c.CountryCode, CASE 
    WHEN c.CurrencyCode = 'EUR' THEN  'Euro'
    ELSE 'Not Euro'
END AS  Currency
FROM dbo.Countries c
ORDER BY c.CountryName
----------------------------------------------------------

SELECT c.CountryName AS [Country Name], c.IsoCode  AS [ISO Code]
FROM dbo.Countries c
WHERE LEN(LOWER(c.CountryName)) -  LEN(REPLACE(LOWER(c.CountryName),'a','')) >= 3
ORDER BY c.IsoCode
-------------------------------------------------------------------

SELECT p.PeakName, m.MountainRange AS Mountain, p.Elevation
FROM dbo.Peaks p
JOIN dbo.Mountains m ON m.Id = p.MountainId
ORDER BY p.Elevation DESC
------------------------------------------------------------------------

SELECT p.PeakName, m.MountainRange AS Mountain, c.CountryName, c2.ContinentName
FROM dbo.Peaks p
JOIN dbo.Mountains m ON m.Id = p.MountainId
JOIN dbo.MountainsCountries mc ON mc.MountainId = m.Id
JOIN  dbo.Countries c ON c.CountryCode = mc.CountryCode
JOIN dbo.Continents c2 ON c2.ContinentCode = c.ContinentCode
ORDER BY p.PeakName, c.CountryName
-------------------------------------------------------------------------------------------

SELECT r.RiverName AS River, COUNT(cr.CountryCode) AS [Countries Count]
FROM dbo.Rivers r
JOIN dbo.CountriesRivers cr ON cr.RiverId = r.Id
GROUP BY r.Id, r.RiverName , cr.RiverId
HAVING COUNT(cr.CountryCode) >= 3
ORDER BY r.RiverName

-------------------------------------------------------------

SELECT MAX(p.Elevation) AS MaxElevation, MIN(p.Elevation) AS MinElevation , AVG(p.Elevation) AverageElevation
FROM dbo.Peaks p

---------------------------

SELECT c.CountryName, c2.ContinentName, COUNT(r.id) AS RiversCount, ISNULL(SUM(r.Length), 0) AS TotalLength
FROM dbo.Rivers r
RIGHT JOIN dbo.CountriesRivers cr ON cr.RiverId = r.Id
RIGHT JOIN dbo.Countries c ON c.CountryCode = cr.CountryCode
RIGHT JOIN dbo.Continents c2 ON c2.ContinentCode = c.ContinentCode
GROUP BY c.CountryCode, c.CountryName, c2.ContinentCode, c2.ContinentName
ORDER BY RiversCount DESC, TotalLength DESC, c.CountryName ASC
------------------------------------------------------------------------------------

SELECT c2.CurrencyCode, c2.Description AS Currency, COUNT(c.CountryCode) AS NumberOfCountries
FROM dbo.Countries c
RIGHT JOIN dbo.Currencies c2 ON c2.CurrencyCode = c.CurrencyCode
GROUP BY c2.CurrencyCode, c2.Description
ORDER BY NumberOfCountries DESC,  c2.Description ASC
----------------------------------------------------------------------------

SELECT c.ContinentName, SUM(CAST(c2.AreaInSqKm AS bigint)) AS CountriesArea, SUM(CAST(c2.Population AS bigint)) AS CountriesPopulation 
FROM dbo.Continents c
JOIN dbo.Countries c2 ON c2.ContinentCode = c.ContinentCode
GROUP BY c.ContinentName
ORDER BY CountriesPopulation DESC
----------------------------------------------------------------------------

SELECT c.CountryName, MAX(p.Elevation) AS HighestPeakElevation, MAX(r.Length) AS LongestRiverLength
FROM dbo.Countries c
LEFT JOIN dbo.CountriesRivers cr ON cr.CountryCode = c.CountryCode
LEFT JOIN dbo.Rivers r ON r.Id = cr.RiverId
LEFT JOIN dbo.MountainsCountries mc ON mc.CountryCode = c.CountryCode
LEFT JOIN dbo.Mountains m ON m.Id = mc.MountainId
LEFT JOIN dbo.Peaks p ON p.MountainId = m.Id
GROUP BY c.CountryCode, c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName
----------------------------------------------------------------------------

SELECT p.PeakName, r.RiverName, LOWER(p.PeakName + RIGHT(r.RiverName, LEN(r.RiverName)-1)) AS Mix
FROM  dbo.Peaks p , dbo.Rivers r
WHERE LOWER(RIGHT(p.PeakName, 1)) = LOWER(LEFT(r.RiverName, 1))
ORDER BY Mix
-- PROBLEM 14--------------------------------------------------------------------------
GO

DECLARE @hiestPeakByCountry TABLE ( Country varchar(45),
		[Highest Peak Name] varchar(max),
		[Highest Peak Elevation] int,	
		[Mountain] varchar(max));


DECLARE countries CURSOR FOR
    SELECT c.CountryName, c.CountryCode
    FROM Countries c
OPEN countries;

DECLARE @countryName varchar(45), @countryCode char(3);

FETCH NEXT FROM countries INTO @countryName, @countryCode;

WHILE @@FETCH_STATUS = 0
BEGIN
    DECLARE @countryMaxPeak  int;
  
    SELECT @countryMaxPeak  = MAX(p.Elevation)
    FROM dbo.MountainsCountries mc
	   LEFT JOIN dbo.Mountains m ON m.Id = mc.MountainId
	   LEFT JOIN dbo.Peaks p ON p.MountainId = m.Id
    WHERE mc.CountryCode = @countryCode

    IF @countryMaxPeak IS NOT NULL
    BEGIN
	   INSERT @hiestPeakByCountry
	   (Country, [Highest Peak Name], [Highest Peak Elevation], Mountain)
	     SELECT @countryName, p.PeakName, p.Elevation, m.MountainRange
		  FROM dbo.MountainsCountries mc
			 LEFT JOIN dbo.Mountains m ON m.Id = mc.MountainId
			 LEFT JOIN dbo.Peaks p ON p.MountainId = m.Id
		  WHERE mc.CountryCode = @countryCode AND p.Elevation = @countryMaxPeak
    END;
    ELSE
    BEGIN
      INSERT @hiestPeakByCountry
      (
          Country, [Highest Peak Name], [Highest Peak Elevation], Mountain
      )
      VALUES
      (
		@countryName, '(no highest peak)', 0, '(no mountain)'
      )
    END;

    FETCH NEXT FROM countries INTO @countryName, @countryCode;

END;

CLOSE countries;
DEALLOCATE countries;

SELECT * FROM @hiestPeakByCountry hpbc ORDER BY hpbc.Country, hpbc.[Highest Peak Name];

GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-----CHANGES IN THE DB 15 --------------------------------------------------------------


CREATE TABLE Monasteries(
	Id int IDENTITY NOT NULL PRIMARY KEY,
	Name nvarchar(200) NOT NULL,
	CountryCode char(2) NOT NULL,
)

GO

ALTER TABLE Monasteries  WITH CHECK ADD  CONSTRAINT FK_Monasteries_Countries FOREIGN KEY(CountryCode)
REFERENCES Countries (CountryCode)
GO

---------------------------------------------------------------------------------------------------

ALTER TABLE dbo.Countries ADD IsDeleted bit NOT NULL CONSTRAINT [DF_Countries_IsDeleted]  DEFAULT ((0))
-----------------------------------------------------------------

UPDATE uc SET uc.IsDeleted = 1
FROM dbo.Countries uc
JOIN  (SELECT c.CountryCode
FROM dbo.Countries c
JOIN dbo.CountriesRivers cr ON cr.CountryCode = c.CountryCode
JOIN dbo.Rivers r ON r.Id = cr.RiverId
GROUP BY c.CountryCode
HAVING COUNT(r.Id) > 3) tuc ON uc.CountryCode = tuc.CountryCode
-----------------------------------------------------------------------------------

SELECT m.Name AS Monastery, c.CountryName AS Country
FROM dbo.Monasteries m
JOIN dbo.Countries c ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted = 0
ORDER BY m.Name
--------------------------------------------------------------------------------------------

------------------------------------16----------------------------------------------------------
UPDATE dbo.Countries  SET CountryName = 'Burma' 
WHERE CountryName = 'Myanmar'
------------------------------------

INSERT dbo.Monasteries
(
    dbo.Monasteries.Name,
    dbo.Monasteries.CountryCode
)
VALUES
(

    N'Hanga Abbey', -- Name - nvarchar
    (SELECT c.CountryCode FROM dbo.Countries c WHERE c.CountryName = 'Tanzania') -- CountryCode - char
)

-----------------------------------------------

INSERT dbo.Monasteries
(
    dbo.Monasteries.Name,
    dbo.Monasteries.CountryCode
)
VALUES
(

    N'Myin-Tin-Daik', -- Name - nvarchar
    (SELECT c.CountryCode FROM dbo.Countries c WHERE c.CountryName = 'Myanmar') -- CountryCode - char
)

--------------------------
SELECT c.ContinentName, c2.CountryName, COUNT(m.Id) AS [MonasteriesCount]
FROM dbo.Continents c
JOIN dbo.Countries c2 ON c2.ContinentCode = c.ContinentCode
LEFT JOIN dbo.Monasteries m ON m.CountryCode = c2.CountryCode
WHERE c2.IsDeleted = 0
GROUP BY c.ContinentName, c2.CountryName
ORDER BY [MonasteriesCount] DESC, c2.CountryName 



---------------------------------------------------------------------------

IF object_id('fn_MountainsPeaksJSON') IS NOT NULL
BEGIN 
	PRINT 'Dropping function'
	DROP FUNCTION fn_MountainsPeaksJSON 
	IF @@ERROR = 0 PRINT 'Function dropped'
END
go

CREATE FUNCTION fn_MountainsPeaksJSON  ()
RETURNS  varchar(max)
BEGIN
   DECLARE mountains CURSOR FOR
    SELECT dbo.Mountains.MountainRange, dbo.Mountains.Id
    FROM Mountains


    OPEN mountains;
    DECLARE @mountainRange varchar(50), @mountainId int, @JSONString varchar(max);
    SET @JSONString = '{"mountains":[';

    FETCH NEXT FROM mountains INTO @mountainRange, @mountainId
    WHILE @@FETCH_STATUS = 0
    BEGIN
	   DECLARE @PartJSONString varchar(max) = '{"name":"' + @mountainRange + '"';
	   
	   DECLARE peaks CURSOR FOR
	   SELECT dbo.Peaks.PeakName, dbo.Peaks.Elevation
	   FROM Peaks
	   WHERE dbo.Peaks.MountainId = @mountainId
	   ORDER BY dbo.Peaks.Id ASC
	   	   
	   OPEN peaks;
	   DECLARE @peaksJSONString varchar(max) = NULL, @peakName varchar(50), @peakElevation int;

	   FETCH NEXT FROM peaks INTO @peakName, @peakElevation;

	   WHILE @@FETCH_STATUS = 0
	   BEGIN
		  IF @peaksJSONString IS NULL
		  BEGIN
			 SET @peaksJSONString = ',"peaks":[' + '{"name":"' + @peakName + '","elevation":' + CAST(@peakElevation as varchar) + '}'
		  END
		  ELSE
		  BEGIN
		  SET @peaksJSONString = @peaksJSONString + ',{"name":"' + @peakName + '","elevation":' + CAST(@peakElevation as varchar) + '}';
		  END
		  FETCH NEXT FROM peaks INTO @peakName, @peakElevation;
	   END;

	   CLOSE peaks;
	   DEALLOCATE peaks;
	   
	   IF @peaksJSONString IS NOT NULL
	   BEGIN
		  SET @peaksJSONString = @peaksJSONString + ']';
		  SET @PartJSONString = @PartJSONString  + @peaksJSONString;
	   END
	   ELSE 
	   BEGIN
		  SET @PartJSONString = @PartJSONString + ',"peaks":[]'
	   END

	   SET @PartJSONString = @PartJSONString + '}'
	   
	   SET @JSONString = @JSONString + @PartJSONString + ',';
	   FETCH NEXT FROM mountains INTO @mountainRange, @mountainId
    END;

    CLOSE mountains;
    DEALLOCATE mountains;

    RETURN LEFT(@JSONString, LEN(@JSONString) -1) + ']}'
END;
    
SELECT  dbo.fn_MountainsPeaksJSON ()