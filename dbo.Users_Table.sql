CREATE TABLE [dbo].[Users]
(
	[UserId] INT PRIMARY KEY IDENTITY (1, 1) NOT NULL, 
    [FirstName] NCHAR(50) NULL, 
    [LastName] NCHAR(50) NULL, 
    [EMail] NCHAR(50) NULL, 
    [Password] NCHAR(50) NULL
)
