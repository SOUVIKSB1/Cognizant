-- ============================================================================
-- Week 1 Assignment: Advanced SQL Exercises for Online Retail Store
-- ============================================================================

-- Setup database tables and insert sample data
IF OBJECT_ID('OrderDetails', 'U') IS NOT NULL DROP TABLE OrderDetails;
IF OBJECT_ID('Orders', 'U') IS NOT NULL DROP TABLE Orders;
IF OBJECT_ID('Products', 'U') IS NOT NULL DROP TABLE Products;
IF OBJECT_ID('Customers', 'U') IS NOT NULL DROP TABLE Customers;
IF OBJECT_ID('StagingProducts', 'U') IS NOT NULL DROP TABLE StagingProducts;

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(100),
    Region VARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Insert Sample Data
INSERT INTO Customers (CustomerID, Name, Region) VALUES
(1, 'Alice', 'North'),
(2, 'Bob', 'South'),
(3, 'Charlie', 'East'),
(4, 'David', 'West'),
(5, 'Eva', 'North');

-- Adding more products to test ranking functions and ties
INSERT INTO Products (ProductID, ProductName, Category, Price) VALUES
(1, 'Laptop', 'Electronics', 1200.00),
(2, 'Smartphone', 'Electronics', 800.00),
(3, 'Tablet', 'Electronics', 600.00),
(4, 'Headphones', 'Accessories', 150.00),
(5, 'Mouse', 'Accessories', 25.00),
(6, 'Keyboard', 'Accessories', 150.00), -- Tie price for Accessories
(7, 'Monitor', 'Electronics', 800.00),     -- Tie price for Electronics
(8, 'Charger', 'Accessories', 25.00);      -- Tie price for Accessories

INSERT INTO Orders (OrderID, CustomerID, OrderDate) VALUES
(1, 1, '2025-01-15'),
(2, 2, '2025-01-20'),
(3, 3, '2025-02-25'),
(4, 4, '2025-02-28'),
(5, 1, '2025-03-10'),
(6, 1, '2025-03-15'),
(7, 1, '2025-04-05'); -- Alice has 4 orders total (1, 5, 6, 7) to test Exercise 5

INSERT INTO OrderDetails (OrderDetailID, OrderID, ProductID, Quantity) VALUES
(1, 1, 1, 1),
(2, 2, 2, 2),
(3, 3, 3, 1),
(4, 4, 4, 3),
(5, 5, 5, 5),
(6, 6, 6, 1),
(7, 7, 1, 1);

-- ============================================================================
-- Exercise 1: Ranking and Window Functions
-- Goal: Find top 3 most expensive products in each category using ROW_NUMBER(), 
-- RANK(), and DENSE_RANK() and compare how ties are handled.
-- ============================================================================

PRINT '--- Exercise 1: Ranking Functions ---';

-- Compare how ROW_NUMBER(), RANK(), and DENSE_RANK() handle price ties
WITH RankedProducts AS (
    SELECT 
        ProductID,
        ProductName,
        Category,
        Price,
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum,
        RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankVal,
        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankVal
    FROM Products
)
SELECT 
    Category,
    ProductName,
    Price,
    RowNum AS [ROW_NUMBER],
    RankVal AS [RANK],
    DenseRankVal AS [DENSE_RANK]
FROM RankedProducts
ORDER BY Category, Price DESC;


-- ============================================================================
-- Exercise 2: Aggregation with GROUPING SETS, CUBE, and ROLLUP
-- Goal: Generate sales reports showing total quantity sold by Region and Category.
-- ============================================================================

PRINT '--- Exercise 2: Grouping Sets, Rollup, and Cube ---';

-- 1. GROUPING SETS: Get totals by Region, Category, both, and grand total
SELECT 
    c.Region, 
    p.Category, 
    SUM(od.Quantity) AS TotalQuantitySold
FROM Orders o
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY GROUPING SETS (
    (c.Region, p.Category),
    (c.Region),
    (p.Category),
    ()
)
ORDER BY GROUPING_ID(c.Region, p.Category), c.Region, p.Category;

-- 2. ROLLUP: Subtotals and grand totals for hierarchical Region -> Category
SELECT 
    c.Region, 
    p.Category, 
    SUM(od.Quantity) AS TotalQuantitySold
FROM Orders o
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY ROLLUP (c.Region, p.Category)
ORDER BY c.Region, p.Category;

-- 3. CUBE: All combinations of Region and Category
SELECT 
    c.Region, 
    p.Category, 
    SUM(od.Quantity) AS TotalQuantitySold
FROM Orders o
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY CUBE (c.Region, p.Category)
ORDER BY c.Region, p.Category;


-- ============================================================================
-- Exercise 3: CTEs and MERGE
-- Goal: Use WITH, CTEs, Recursive CTEs, and MERGE.
-- ============================================================================

PRINT '--- Exercise 3: Recursive CTE and MERGE ---';

-- a) Recursive CTE to generate a calendar table from '2025-01-01' to '2025-01-31'
WITH CalendarCTE AS (
    SELECT CAST('2025-01-01' AS DATE) AS DateValue
    UNION ALL
    SELECT DATEADD(day, 1, DateValue)
    FROM CalendarCTE
    WHERE DateValue < '2025-01-31'
)
SELECT DateValue 
FROM CalendarCTE
OPTION (MAXRECURSION 31);

-- b) Staging table creation and MERGE statement
CREATE TABLE StagingProducts (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);

-- Populate Staging table with modifications and a new product
INSERT INTO StagingProducts (ProductID, ProductName, Category, Price) VALUES
(1, 'Laptop Elite', 'Electronics', 1350.00), -- Updated Name & Price
(3, 'Tablet Pro', 'Electronics', 550.00),     -- Updated Name & Price
(9, 'Wireless Mouse', 'Accessories', 29.99);  -- Brand New Product

-- Perform the MERGE
MERGE Products AS target
USING StagingProducts AS source
ON target.ProductID = source.ProductID
WHEN MATCHED THEN
    UPDATE SET 
        target.ProductName = source.ProductName,
        target.Category = source.Category,
        target.Price = source.Price
WHEN NOT MATCHED BY TARGET THEN
    INSERT (ProductID, ProductName, Category, Price)
    VALUES (source.ProductID, source.ProductName, source.Category, source.Price);

-- Display results after MERGE
SELECT * FROM Products;


-- ============================================================================
-- Exercise 4: PIVOT and UNPIVOT
-- Goal: Transform monthly sales quantities from rows to columns, then back.
-- ============================================================================

PRINT '--- Exercise 4: PIVOT and UNPIVOT ---';

-- 1. PIVOT: Convert month rows into columns
WITH MonthlySales AS (
    SELECT 
        p.ProductName, 
        DATENAME(month, o.OrderDate) AS MonthName, 
        od.Quantity
    FROM Orders o
    JOIN OrderDetails od ON o.OrderID = od.OrderID
    JOIN Products p ON od.ProductID = p.ProductID
)
SELECT ProductName, 
       ISNULL([January], 0) AS [January], 
       ISNULL([February], 0) AS [February], 
       ISNULL([March], 0) AS [March], 
       ISNULL([April], 0) AS [April]
FROM MonthlySales
PIVOT (
    SUM(Quantity)
    FOR MonthName IN ([January], [February], [March], [April])
) AS PivotedTable;

-- 2. UNPIVOT: Convert columns back into row format
WITH PivotedSales AS (
    SELECT ProductName, 
           ISNULL([January], 0) AS [January], 
           ISNULL([February], 0) AS [February], 
           ISNULL([March], 0) AS [March], 
           ISNULL([April], 0) AS [April]
    FROM (
        SELECT 
            p.ProductName, 
            DATENAME(month, o.OrderDate) AS MonthName, 
            od.Quantity
        FROM Orders o
        JOIN OrderDetails od ON o.OrderID = od.OrderID
        JOIN Products p ON od.ProductID = p.ProductID
    ) AS MS
    PIVOT (
        SUM(Quantity)
        FOR MonthName IN ([January], [February], [March], [April])
    ) AS Piv
)
SELECT ProductName, MonthName, Quantity
FROM PivotedSales
UNPIVOT (
    Quantity FOR MonthName IN ([January], [February], [March], [April])
) AS UnpivotedTable;


-- ============================================================================
-- Exercise 5: Using CTE to Simplify a Query
-- Goal: Find all customers who have placed more than 3 orders.
-- ============================================================================

PRINT '--- Exercise 5: Simplify query using CTE ---';

WITH CustomerOrderCounts AS (
    SELECT 
        o.CustomerID,
        COUNT(o.OrderID) AS OrderCount
    FROM Orders o
    GROUP BY o.CustomerID
)
SELECT 
    c.CustomerID,
    c.Name,
    coc.OrderCount
FROM CustomerOrderCounts coc
JOIN Customers c ON c.CustomerID = coc.CustomerID
WHERE coc.OrderCount > 3;
