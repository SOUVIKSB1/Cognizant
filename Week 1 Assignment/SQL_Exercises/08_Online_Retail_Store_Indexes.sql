-- ============================================================================
-- Week 1 Assignment: Online Retail Store - Database Indexing Exercises
-- ============================================================================

-- Setup database tables and insert sample data
IF OBJECT_ID('OrderDetails', 'U') IS NOT NULL DROP TABLE OrderDetails;
IF OBJECT_ID('Orders', 'U') IS NOT NULL DROP TABLE Orders;
IF OBJECT_ID('Products', 'U') IS NOT NULL DROP TABLE Products;
IF OBJECT_ID('Customers', 'U') IS NOT NULL DROP TABLE Customers;

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

-- Note: To create a clustered index on OrderDate, we must define the PRIMARY KEY
-- on OrderID as NONCLUSTERED, because SQL Server tables default to creating the 
-- clustered index on the Primary Key. A table can have only ONE clustered index.
CREATE TABLE Orders (
    OrderID INT CONSTRAINT PK_Orders PRIMARY KEY NONCLUSTERED,
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
(4, 'David', 'West');

INSERT INTO Products (ProductID, ProductName, Category, Price) VALUES
(1, 'Laptop', 'Electronics', 1200.00),
(2, 'Smartphone', 'Electronics', 800.00),
(3, 'Tablet', 'Electronics', 600.00),
(4, 'Headphones', 'Accessories', 150.00);

INSERT INTO Orders (OrderID, CustomerID, OrderDate) VALUES
(1, 1, '2023-01-15'),
(2, 2, '2023-02-20'),
(3, 3, '2023-03-25'),
(4, 4, '2023-04-30');

INSERT INTO OrderDetails (OrderDetailID, OrderID, ProductID, Quantity) VALUES
(1, 1, 1, 1),
(2, 2, 2, 2),
(3, 3, 3, 1),
(4, 4, 4, 3);
GO

-- ============================================================================
-- Exercise 1: Creating a Non-Clustered Index
-- Goal: Create a non-clustered index on the ProductName column in the Products table 
-- and compare query execution time before and after index creation.
-- ============================================================================

PRINT '--- Exercise 1: Non-Clustered Index ---';

-- Step 1: Query to fetch product details before index creation
SELECT * FROM Products WHERE ProductName = 'Laptop';

-- Step 2: Create a non-clustered index on ProductName
CREATE NONCLUSTERED INDEX IX_Products_ProductName 
ON Products(ProductName);
GO

-- Step 3: Query to fetch product details after index creation (uses index seek instead of scan)
SELECT * FROM Products WHERE ProductName = 'Laptop';
GO


-- ============================================================================
-- Exercise 2: Creating a Clustered Index
-- Goal: Create a clustered index on the OrderDate column in the Orders table 
-- and compare query execution before and after.
-- ============================================================================

PRINT '--- Exercise 2: Clustered Index ---';

-- Step 1: Query to fetch orders before index creation
SELECT * FROM Orders WHERE OrderDate = '2023-01-15';

-- Step 2: Create a clustered index on OrderDate
CREATE CLUSTERED INDEX IX_Orders_OrderDate 
ON Orders(OrderDate);
GO

-- Step 3: Query to fetch orders after index creation (table data is physically sorted by OrderDate)
SELECT * FROM Orders WHERE OrderDate = '2023-01-15';
GO


-- ============================================================================
-- Exercise 3: Creating a Composite Index
-- Goal: Create a composite index on the CustomerID and OrderDate columns in 
-- the Orders table and compare.
-- ============================================================================

PRINT '--- Exercise 3: Composite Index ---';

-- Step 1: Query to fetch orders before index creation
SELECT * FROM Orders WHERE CustomerID = 1 AND OrderDate = '2023-01-15';

-- Step 2: Create a composite index on CustomerID and OrderDate
CREATE NONCLUSTERED INDEX IX_Orders_CustomerID_OrderDate 
ON Orders(CustomerID, OrderDate);
GO

-- Step 3: Query to fetch orders after index creation
SELECT * FROM Orders WHERE CustomerID = 1 AND OrderDate = '2023-01-15';
GO
