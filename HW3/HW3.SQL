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

