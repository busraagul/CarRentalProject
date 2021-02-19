CREATE TABLE Cars
(
	CarId int PRIMARY KEY IDENTITY(1,1),
	BrandId int,
	ColorId int,
	ModelYear int,
	DailyPrice decimal,
	Descriptions nvarchar(25),
	--FOREIGN KEY (ColorId) REFERENCES Colors(ColorId),
	--FOREIGN KEY (BrandId) REFERENCES Brands(BrandId)
	);

CREATE TABLE Brands
(
	BrandId int PRIMARY KEY IDENTITY(1,1),
	BrandName nvarchar(25),
)


CREATE TABLE Colors
(
	ColorId int PRIMARY KEY IDENTITY(1,1),
	ColorName nvarchar(25),
)

INSERT INTO Cars(BrandId,ColorId,ModelYear,DailyPrice,Descriptions)
Values 
('1','12','2019','750','Otomatik Hybrd'),
('5','7','2020','600','Otomatik Dizel'),
('1','4','2017','300','Otomatik Dizel'),
('2','12','2001','100','Manuel Benzin');

