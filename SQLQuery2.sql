CREATE TABLE Cars(
	Id int PRIMARY KEY IDENTITY(1,1),
	BrandId int,
	ColorId int,
	ModelYear int,
	DailyPrice decimal,
	Description nvarchar(25),
	);

CREATE TABLE Brands(
	BrandId int PRIMARY KEY IDENTITY(1,1),
	BrandName nvarchar(25),
)


CREATE TABLE Colors(
	ColorId int PRIMARY KEY IDENTITY(1,1),
	ColorName nvarchar(25),
)

INSERT INTRO 
VALUES 
('1','1','12','2020','750','Otomatik Hybrd'),
('2','5','7','2020','600','Otomatik Dizel'),
('3','1','4','2017','300','Otomatik Dizel'),
('4','2','12','2001','100','Manuel Benzin');



	