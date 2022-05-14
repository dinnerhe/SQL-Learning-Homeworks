USE Northwind
go

-- 1
CREATE VIEW view_product_order_he AS
(
    SELECT ProductID, SUM(Quantity) [Total Quantity]
    FROM [Order Details]
    GROUP BY ProductID
)

go

SELECT * FROM dbo.view_product_order_he
go
--2
CREATE PROC sp_product_order_quantity_he
@pid INT,
@TotalQuantity INT OUT
AS
BEGIN
    SELECT @TotalQuantity =  dt.[Total Quantity]
    FROM (
        SELECT ProductID, SUM(Quantity) [Total Quantity]
        FROM [Order Details]
        GROUP BY ProductID) as dt
    WHERE dt.ProductID = @pid
END
GO

DECLARE @quantity INT
EXEC sp_product_order_quantity_he 46, @quantity OUT
PRINT @quantity
DROP PROC sp_product_order_quantity_he
GO

--3
CREATE PROC sp_product_order_city_he
@pName VARCHAR(30)
AS
BEGIN
    WITH OrderInformation
    AS(
        SELECT o.OrderID, o.ShipCity, od.ProductID, od.Quantity
        FROM Orders as o JOIN [Order Details] as od
        ON o.OrderID = od.OrderID
    )
    SELECT TOP 5 oi.ShipCity, SUM(oi.Quantity) [Total Quantity]
    FROM Products as p JOIN  OrderInformation as oi
    ON p.ProductID = oi.ProductID
    GROUP BY p.ProductName, oi.ShipCity
    HAVING  p.ProductName = @pName
    ORDER BY [Total Quantity] DESC
END
GO


WITH OrderInformation
AS(
    SELECT o.OrderID, o.ShipCity, od.ProductID, od.Quantity
    FROM Orders as o JOIN [Order Details] as od
    ON o.OrderID = od.OrderID
)
SELECT  p.ProductName, oi.ShipCity, SUM(oi.Quantity) [Total Quantity]
FROM Products as p JOIN  OrderInformation as oi
ON p.ProductID = oi.ProductID
GROUP BY p.ProductName, oi.ShipCity
ORDER BY p.ProductName, [Total Quantity] DESC

EXEC sp_product_order_city_he 'Aniseed Syrup'


DROP PROC sp_product_order_city_he
GO
-- 4
CREATE TABLE city_he(
Id INT PRIMARY KEY,
City VARCHAR(30)
)
INSERT INTO dbo.city_he VALUES (1, 'Seattle'), (2, 'Green Bay')


CREATE TABLE people_he(
Id INT,
Name VARCHAR(30),
City INT FOREIGN KEY REFERENCES city_he(Id)
)
INSERT INTO dbo.people_he VALUES (1, 'Aaron Rodgers', 2), (2, 'Russell Wilson', 1), (3, 'Jody Nelson', 2)
GO 
SELECT * FROM people_he
SELECT * FROM city_he
UPDATE city_he SET City = 'Madison' WHERE City = 'Seattle'
go
CREATE VIEW Packers_he AS(
    SELECT  p.Name [Name], p.Id [PeopleId], p.City[CityId], c.City[CityName]
    FROM people_he as p JOIN city_he as c
    ON p.City = c.Id
    WHERE c.City = 'Green Bay'
)
go
SELECT * from Packers_he
DROP TABLE people_he
DROP TABLE city_he
DROP VIEW Packers_he
go
-- 5
CREATE PROC sp_birthday_employees_he
AS
BEGIN
    CREATE TABLE birthday_employees_he(
        Name VARCHAR(30),
        Birthday DATE
    )
    INSERT INTO birthday_employees_he 
    SELECT CONCAT(FirstName, LastName), BirthDate
    FROM Employees
    WHERE MONTH(BirthDate) = 2
    

END
go
EXEC sp_birthday_employees_he
SELECT * FROM birthday_employees_he

DROP TABLE birthday_employees_he
DROP PROC sp_birthday_employees_he
-- 6. INTERSECT two table and see if the results is the same as one table