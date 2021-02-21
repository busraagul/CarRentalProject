CREATE TABLE [dbo].[Rentals]
(
	[RentalId] INT  PRIMARY KEY IDENTITY (1, 1) NOT NULL, 
    [CarId] INT NULL, 
    [CustomerId] INT NULL, 
    [RentDate] DATETIME NULL, 
    [ReturnDate] DATETIME NULL, 
    CONSTRAINT [FK_Rentals_Cars] FOREIGN KEY ([CarId]) REFERENCES [Cars]([CarId]), 
    CONSTRAINT [FK_Rentals_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [Customers]([CustomerId]) 
)
