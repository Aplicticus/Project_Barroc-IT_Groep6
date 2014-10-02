CREATE TABLE tbl_Projects
(
	ProjectID INT IDENTITY(1,1) PRIMARY KEY,
	CustomerID INT NOT NULL,
	Name varchar(30) NOT NULL,
	Deadline DATE NOT NULL,
	Subject varchar(30) NOT NULL
)