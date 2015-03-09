INSERT INTO [dbo].[WorkHours]
           ([WorkDate]
           ,[EmployeeID]
           ,[Task]
           ,[WorkHours]
           ,[Comment])
     VALUES
           (GETDATE(),
            2,
           'task 1',
           3,
           'task 1 comment');
 
INSERT INTO [dbo].[WorkHours]
           ([WorkDate]
           ,[EmployeeID]
           ,[Task]
           ,[WorkHours]
           ,[Comment])
     VALUES
           (GETDATE(),
            4,
           'task 2',
           3,
           'task 2 comment');
 
INSERT INTO [dbo].[WorkHours]
           ([WorkDate]
           ,[EmployeeID]
           ,[Task]
           ,[WorkHours]
           ,[Comment])
     VALUES
           (GETDATE(),
            2,
           'task 1',
           3,
           NULL);
 
UPDATE WorkHours SET Comment = 'No comment'
WHERE Comment IS NULL;
 
DELETE FROM WorkHours WHERE EmployeeID = 4;