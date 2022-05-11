USE AdventureWorks2019
-- 1
SELECT ProductID, Name, Color, ListPrice FROM Production.Product
-- 2
SELECT ProductID, Name, Color, ListPrice 
FROM Production.Product
WHERE ListPrice != 0 
-- 3
SELECT ProductID, Name, Color, ListPrice 
FROM Production.Product
WHERE Color IS NOT NULL
-- 4
SELECT ProductID, Name, Color, ListPrice 
FROM Production.Product
WHERE Color IS NOT NULL AND ListPrice > 0
-- 5
SELECT Name + ' ' + Color as NAMECOLOR
FROM Production.Product
WHERE Color IS NOT NULL
-- 6
select Name, Color 
from Production.Product
WHERE Name LIKE '%Crankarm%' OR Name LIKE 'Chainring%' AND Color IN ('Black', 'Silver')
-- 7
SELECT ProductID, Name
FROM Production.Product
WHERE ProductID >= 400 AND ProductID <= 500
-- 8
SELECT ProductID, Name, Color
FROM Production.Product
WHERE Color IN ('Black', 'Blue')
-- 9
select * from Production.Product
WHERE Name like 'S%'
-- 10
SELECT Name, ListPrice
FROM Production.Product
WHERE Name like 'S%' OR Name like 'A%'
ORDER BY Name ASC 
OFFSET 0 ROWS FETCH NEXT 5 ROW ONLY
-- 11
select * from Production.Product
WHERE Name like 'SPO[^K]%'
ORDER BY Name ASC 
--12  
SELECT distinct ISNULL(ProductSubcategoryID, 0) [ProductSubcategoryID] , ISNULL(Color, 'N/A') [Color] from Production.Product 