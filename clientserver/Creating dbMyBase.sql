USE master 
GO
DROP DATABASE IF EXISTS dbMyBase
GO
CREATE DATABASE dbMyBase
GO
USE dbMyBase
GO
CREATE TABLE dbo.Employees (ID INT IDENTITY PRIMARY KEY, 
							Name Nvarchar(50) NOT NULL, 
							SecondName Nvarchar(50) NOT NULL, 
							Patronymic Nvarchar(50) NOT NULL,
							Age INT)
GO
INSERT INTO dbo.Employees (Name, SecondName, Patronymic, Age) VALUES ('Petrov','Petr','Petrovich',20),
								 ('Ivan','Ivanov','Ivanovich',25),
								 ('Oleg','Olegov','Olegovich',30),
								 ('Gomer','Simpson','Foxovich',40),
								 ('Vladimir','Pupin','Vladislavovich',70),
								 ('Lebed','Golybkov','Samsonovich',35),
								 ('Dazdraperma','Chemodanova','Shkafovna',34),
								 ('Semen','Vavilov','Olegovich',23),
								 ('Potap','Kondratev','Bobovich',26),
								 ('Georgii','Jopov','Plohovich',63),
								 ('Lev','Svarovski','Kristalovich',53)
GO
CREATE PROCEDURE AddEmployee @name Nvarchar(50), @secondname Nvarchar(50), @patronymic Nvarchar(50), @age INT
AS 
INSERT INTO Employees(Name, SecondName,Patronymic,Age) VALUES (@name, @secondname, @patronymic, @age)
GO
CREATE PROCEDURE DeleteEmployee @id INT
AS
DELETE FROM Employees WHERE ID=@id
GO
CREATE PROCEDURE ShowList @fst INT, @snd INT
AS
SELECT * FROM Employees ORDER BY ID OFFSET @fst ROWS FETCH  NEXT @snd ROWS ONLY
GO