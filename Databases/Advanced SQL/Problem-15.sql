CREATE TABLE Users
(
Id int IDENTITY PRIMARY KEY,
Username varchar(255),
Password varchar(255) ,
FirstName varchar(255),
LastName varchar(255),
LastLogin smalldatetime,
);

INSERT INTO [dbo].[Users]
           ([UserName]
           ,[Password]
           ,[FirstName]
           ,[LastName]
           ,[LastLogin])
     VALUES
           ('Nakata',
            'passwd',
            'Svetlin',
			 'Nakov',
            GETDATE());
 
INSERT INTO [dbo].[Users]
           ([UserName]
           ,[Password]
           ,[FirstName]
           ,[LastName]
           ,[LastLogin])
     VALUES
           ('Nakata2',
            'passwd',
            'Svetlin',
			'Nakov 2',
            '2015-02-11');
 