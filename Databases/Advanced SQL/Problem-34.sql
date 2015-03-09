CREATE TABLE ##TempEmpProjectsBakup
(
	[EmployeeID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL
)



INSERT INTO ##TempEmpProjectsBakup 
SELECT * FROM EmployeesProjects

SELECT * FROM TempDB.information_schema.tables

DROP TABLE EmployeesProjects

CREATE TABLE EmployeesProjects(
  EmployeeID int NOT NULL,
  ProjectID int NOT NULL,
  CONSTRAINT PK_EmployeesProjects PRIMARY KEY CLUSTERED (EmployeeID ASC, ProjectID ASC)
)

INSERT INTO EmployeesProjects
SELECT * FROM ##TempEmpProjectsBakup

DROP TABLE ##TempEmpProjectsBakup
