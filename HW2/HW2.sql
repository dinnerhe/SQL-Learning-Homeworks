USE AdventureWorks2019
go
SELECT * from Person.CountryRegion
order by Name
--
SELECT * from Person.StateProvince
order by IsOnlyStateProvinceFlag, Name
--
SELECT DISTINCT * 
FROM Person.CountryRegion as c INNER JOIN Person.StateProvince as s
ON c.CountryRegionCode = s.CountryRegionCode
order by c.Name
-- 1
SELECT DISTINCT c.Name [Country], s.Name [Province]
FROM Person.CountryRegion as c INNER JOIN Person.StateProvince as s
ON c.CountryRegionCode = s.CountryRegionCode
order by Country
-- 2
SELECT DISTINCT c.Name [Country], s.Name [Province]
FROM Person.CountryRegion as c INNER JOIN Person.StateProvince as s
ON c.CountryRegionCode = s.CountryRegionCode
WHERE c.Name NOT IN  ('Germany', 'Canada')
ORDER BY Country asc

-- 
use Northwind
go
-- 3
WITH OrderI(OrderID, ProductID, OrderDate)
AS(
    SELECT o.OrderID, d.ProductID, o.OrderDate
    FROM Orders as o INNER JOIN [Order Details] as d
    ON o.OrderID = d.OrderID
)
SELECT DISTINCT p.ProductID, p.ProductName
FROM Products p INNER JOIN OrderI as i 
ON p.ProductID = i.ProductID 
ORDER BY p.ProductName

-- 3 with COUNT
WITH OrderI(OrderID, ProductID, OrderDate)
AS(
    SELECT o.OrderID, d.ProductID, o.OrderDate
    FROM Orders as o INNER JOIN [Order Details] as d
    ON o.OrderID = d.OrderID
    WHERE o.OrderDate > YEAR(1997)
)
SELECT DISTINCT p.ProductID, p.ProductName,  Count(p.ProductName) Over(Partition By p.ProductName) as 'Total'
FROM Products p INNER JOIN OrderI as i 
ON p.ProductID = i.ProductID 
ORDER BY p.ProductName

-- 4
select ShipPostalCode, COUNT(OrderID) as OrderCount
from Orders
WHERE OrderDate > YEAR(1997)
GROUP BY ShipPostalCode
ORDER BY OrderCount DESC
-- 5
select City, COUNT(CustomerID) as CustomerCount
from Customers
GROUP BY City
order by City

-- 6
select City, COUNT(CustomerID) as CustomerCount
from Customers
GROUP BY City
HAVING COUNT(CustomerID) >=2
order by City

-- 7 

SELECT o.CustomerID, SUM(d.Quantity) as ProductCount
    FROM Orders as o INNER JOIN [Order Details] as d
    ON o.OrderID = d.OrderID
    GROUP BY o.CustomerID
-- 8
SELECT o.CustomerID, SUM(d.Quantity) as ProductCount
    FROM Orders as o INNER JOIN [Order Details] as d
    ON o.OrderID = d.OrderID
    GROUP BY o.CustomerID
    HAVING SUM(d.Quantity) > 100

-- 9
WITH SupplierData
AS(
    SELECT p.ProductID, p.SupplierID, s.CompanyName [SupplyName]
    FROM Products as p JOIN Suppliers as s
    ON p.SupplierID = s.SupplierID 
), OrderSupplier
AS(
    SELECT od.OrderID, od.ProductID, sd.SupplierID, sd.SupplyName
    FROM [Order Details] as od JOIN SupplierData as sd
    ON od.ProductID = sd.ProductID
), MOrderDetail
AS(
    SELECT os.*, o.ShipVia
    FROM Orders as o JOIN OrderSupplier as os
    ON o.OrderID = os.OrderID
), OSS
AS(
    SELECT mo.*, s.CompanyName [ShipperName]
    FROM Shippers as s JOIN MOrderDetail as mo
    ON s.ShipperID = mo.ShipVia
)
select DISTINCT SupplyName  [Supplier Company Name] , ShipperName  [Shipping Company Name] from OSS





-- 10 
WITH OrderI(OrderID, ProductID, OrderDate)
AS(
    SELECT o.OrderID, d.ProductID, o.OrderDate
    FROM Orders as o INNER JOIN [Order Details] as d
    ON o.OrderID = d.OrderID
)
SELECT i.OrderDate, p.ProductName
FROM Products p INNER JOIN OrderI as i 
ON p.ProductID = i.ProductID 
ORDER BY i.OrderDate

-- 11

SELECT dt.[Employee 1], dt.[Employee 2]
FROM(
SELECT e1.FirstName + ' ' + e1.LastName [Employee 1], e2.FirstName + ' ' + e2.LastName [Employee 2] 
FROM Employees as e1 INNER JOIN Employees as e2
ON e1.Title = e2.Title) as dt
WHERE dt.[Employee 1]> dt.[Employee 2]

-- 12
SELECT e.FirstName + ' ' + e.LastName as Manager
FROM Employees as e INNER JOIN (
SELECT e2.EmployeeID, COUNT(e1.EmployeeID) [ReportCount]
FROM Employees as e1 INNER JOIN Employees as e2
ON (e1.FirstName != e2.FirstName or e1.LastName != e2.LastName) AND e1.ReportsTo = e2.EmployeeID
GROUP BY e2.EmployeeID
HAVING COUNT(e1.EmployeeID) >2
) as inf
ON e.EmployeeID = inf.EmployeeID

-- 12 Draft
select * from Employees

SELECT e1.FirstName + ' ' + e1.LastName [Employee 1], e1.EmployeeID, e1.ReportsTo ,e2.FirstName + ' ' + e2.LastName [Employee 2], e2.EmployeeID
FROM Employees as e1 INNER JOIN Employees as e2
ON (e1.FirstName != e2.FirstName or e1.LastName != e2.LastName) AND e1.ReportsTo = e2.EmployeeID

SELECT e2.EmployeeID, COUNT(e1.EmployeeID) [ReportCount]
FROM Employees as e1 INNER JOIN Employees as e2
ON (e1.FirstName != e2.FirstName or e1.LastName != e2.LastName) AND e1.ReportsTo = e2.EmployeeID
GROUP BY e2.EmployeeID
HAVING COUNT(e1.EmployeeID) >2

-- 13
SELECT City, CompanyName [Name], ContactName[ContactName], 'Customer' [Type]
FROM Customers
UNION
SELECT City, CompanyName [Name], ContactName[ContactName], 'Suppliers' [Type]
FROM Suppliers
ORDER BY City

--
use Northwind
go

--14
SELECT cc.City
FROM (
    SELECT City, COUNT(CustomerID) as [CustomerCount]
    FROM Customers
    GROUP BY City
) as cc INNER JOIN (
    SELECT City, COUNT(EmployeeID) as [EmployeeCount]
    FROM Employees
    GROUP BY City
) as ec
ON cc.City = ec.City
WHERE cc.CustomerCount >0 and ec.EmployeeCount >0

-- 15 a.
SELECT DISTINCT  City
    FROM Customers
WHERE City NOT IN
(
    SELECT DISTINCT City
    FROM Employees
) 

-- 15 b.

SELECT DISTINCT City
FROM Customers as c
EXCEPT
SELECT DISTINCT City
FROM Employees

-- 16
SELECT p.ProductName, p.ProductID, SUM(od.Quantity)[Total Order Quantity]
FROM Products as p LEFT JOIN [Order Details] as od
ON p.ProductID = od.ProductID 
GROUP BY p.ProductName, p.ProductID
ORDER BY p.ProductID 

-- 17 a.
SELECT City
FROM Customers
GROUP BY City
HAVING COUNT(CustomerID) >=2
UNION
SELECT City
FROM Customers
GROUP BY City
HAVING COUNT(CustomerID) >=2

-- 17 b. 
SELECT cc.City as City
FROM(
    SELECT City, COUNT(CustomerID) as CCount
    FROM Customers
    GROUP BY City
    HAVING COUNT(CustomerID) >=2
) as cc

-- 18

SELECT o.ShipCity, COUNT(DISTINCT od.ProductID) [ProductKindCount]
FROM Orders o INNER JOIN [Order Details] od
ON o.OrderID = od.OrderID
GROUP BY o.ShipCity
HAVING COUNT(DISTINCT od.ProductID) >= 2

-- 19


WITH RankDetail AS(
    SELECT  s.ProductID, dt.ShipCity as[Top City]
    FROM (
        SELECT TOP 5 ProductID, SUM(Quantity) as QSUM
        FROM [Order Details]
        GROUP BY ProductID
        ORDER BY QSUM desc
    )as s INNER JOIN(
        SELECT o.ShipCity, od.ProductID, SUM(od.Quantity) [Quantity of Products], RANK() Over(Partition by od.ProductID Order BY SUM(od.Quantity) desc) [PRank]
        FROM Orders as o LEFT JOIN [Order Details] as od
        ON o.OrderID = od.OrderID
        GROUP BY o.ShipCity, od.ProductID
    ) as dt
    ON s.ProductID = dt.ProductID
    WHERE PRank =1
)
SELECT p.ProductID, p.ProductName, UnitPrice  [AVERAGE UNIT PRICE], rd.[Top City]
FROM Products as p INNER JOIN RankDetail as rd
ON p.ProductID = rd.ProductID


-- 20

SELECT * 
FROM (
    SELECT TOP 1 ShipCity, COUNT(OrderID) [Order Count]
    FROM Orders
    GROUP BY ShipCity
    Order By [Order Count] DESC
) AS oc INNER JOIN(
    SELECT TOP 1 o.ShipCity, SUM(od.Quantity) [Quantity of Products]
    FROM Orders as o LEFT JOIN [Order Details] as od
    ON o.OrderID = od.OrderID
    GROUP BY o.ShipCity
    ORDER BY [Quantity of Products] DESC
) AS qc
ON oc.ShipCity = qc.ShipCity



-- most order
SELECT ShipCity, COUNT(OrderID) [Order Count]
FROM Orders
GROUP BY ShipCity
Order By [Order Count] DESC

-- most quantity
SELECT o.ShipCity, SUM(od.Quantity) [Quantity of Products]
FROM Orders as o LEFT JOIN [Order Details] as od
ON o.OrderID = od.OrderID
GROUP BY o.ShipCity
ORDER BY [Quantity of Products] DESC

-- 21
SELECT OrderID
FROM [Order Details]
UNION
SELECT OrderID
FROM [Order Details]