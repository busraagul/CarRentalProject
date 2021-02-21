CREATE TABLE [dbo].[Cars] (
    [CarId]        INT           IDENTITY (1, 1) NOT NULL,
    [BrandId]      INT           NULL,
    [ColorId]      INT           NULL,
    [ModelYear]    INT           NULL,
    [DailyPrice]   DECIMAL (18)  NULL,
    [Descriptions] NVARCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([CarId] ASC), 
    CONSTRAINT [FK_Cars_ToBrands] FOREIGN KEY (BrandId) REFERENCES [Brands]([BrandId]), 
    CONSTRAINT [FK_Cars_Colors] FOREIGN KEY ([ColorId]) REFERENCES [Colors]([ColorId])

);

