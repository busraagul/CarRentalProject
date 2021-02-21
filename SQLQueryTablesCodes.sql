CREATE TABLE [dbo].[Cars] (
    [CarId]        INT    PRIMARY KEY       IDENTITY (1, 1) NOT NULL,
    [BrandId]      INT           NULL,
    [ColorId]      INT           NULL,
    [ModelYear]    INT           NULL,
    [DailyPrice]   DECIMAL (18)  NULL,
    [Descriptions] NVARCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([CarId] ASC),
    CONSTRAINT [FK_Cars_ToBrands] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([BrandId]),
    CONSTRAINT [FK_Cars_ToColors] FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([ColorId])
);



CREATE TABLE [dbo].[Brands]
(
	[BrandId] INT NOT NULL PRIMARY KEY, 
    [BrandName] NCHAR(25) NULL
);


CREATE TABLE [dbo].[Brands]
(
	[BrandId] INT NOT NULL PRIMARY KEY, 
    [BrandName] NCHAR(25) NULL
);


CREATE TABLE [dbo].[Colors] (
    [ColorId]   INT           IDENTITY (1, 1) NOT NULL,
    [ColorName] NVARCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([ColorId] ASC)
);


CREATE TABLE [dbo].[Customers] (
    [CustomerId]  INT        IDENTITY (1, 1) NOT NULL,
    [UserId]      INT        NULL,
    [CompanyName] NCHAR (75) NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC),
    CONSTRAINT [FK_Customers_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);



CREATE TABLE [dbo].[Rentals] (
    [RentalId]   INT      NOT NULL,
    [CarId]      INT      NULL,
    [CustomerId] INT      NULL,
    [RentDate]   DATETIME NULL,
    [ReturnDate] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([RentalId] ASC),
    CONSTRAINT [FK_Rentals_ToCars] FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([CarId]),
    CONSTRAINT [FK_Rentals_ToCustomers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId])
);



CREATE TABLE [dbo].[Users] (
    [UserId]    INT        IDENTITY (1, 1) NOT NULL,
    [FirstName] NCHAR (50) NULL,
    [LastName]  NCHAR (50) NULL,
    [EMail]     NCHAR (50) NULL,
    [Password]  NCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);





