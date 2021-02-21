CREATE TABLE [dbo].[Customers]
(
	[CustomerId] INT PRIMARY KEY IDENTITY (1, 1) NOT NULL, 
    [UserId] INT NOT NULL, 
    [CompanyName] NCHAR(75) NULL, 
    CONSTRAINT [FK_Customers_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId])
)
