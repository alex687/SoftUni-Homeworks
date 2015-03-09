CREATE VIEW TodayVisitors AS
SELECT *
FROM Users
WHERE DAY(LastLogin) = DAY(GETDATE());

 
SELECT * FROM TodayVisitors;
 