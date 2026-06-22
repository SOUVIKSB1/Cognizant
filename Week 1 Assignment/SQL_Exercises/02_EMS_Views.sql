-- ============================================================================
-- Week 1 Assignment: Employee Management System - SQL Views Exercises
-- ============================================================================

-- Setup database tables and insert sample data
IF OBJECT_ID('vw_EmployeeReport', 'V') IS NOT NULL DROP VIEW vw_EmployeeReport;
IF OBJECT_ID('vw_EmployeeAnnualSalary', 'V') IS NOT NULL DROP VIEW vw_EmployeeAnnualSalary;
IF OBJECT_ID('vw_EmployeeFullName', 'V') IS NOT NULL DROP VIEW vw_EmployeeFullName;
IF OBJECT_ID('vw_EmployeeBasicInfo', 'V') IS NOT NULL DROP VIEW vw_EmployeeBasicInfo;

IF OBJECT_ID('Employees', 'U') IS NOT NULL DROP TABLE Employees;
IF OBJECT_ID('Departments', 'U') IS NOT NULL DROP TABLE Departments;

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10, 2),
    JoinDate DATE
);

-- Insert Sample Data
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing');

INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'),
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'),
(3, 'Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
(4, 'Emily', 'Davis', 4, 5500.00, '2021-11-05');

-- ============================================================================
-- Exercise 1: Create a Simple View
-- Goal: Create a view to show basic employee details.
-- ============================================================================
GO
CREATE VIEW vw_EmployeeBasicInfo AS
SELECT 
    e.EmployeeID, 
    e.FirstName, 
    e.LastName, 
    d.DepartmentName
FROM Employees e
INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID;
GO

PRINT '--- Verification for Exercise 1 ---';
SELECT * FROM vw_EmployeeBasicInfo;


-- ============================================================================
-- Exercise 2: Add Computed Column - Full Name
-- Goal: Use a computed column in a view.
-- ============================================================================
GO
CREATE VIEW vw_EmployeeFullName AS
SELECT 
    EmployeeID, 
    FirstName + ' ' + LastName AS FullName, 
    Salary, 
    JoinDate
FROM Employees;
GO

PRINT '--- Verification for Exercise 2 ---';
SELECT * FROM vw_EmployeeFullName;


-- ============================================================================
-- Exercise 3: Add Computed Column - Annual Salary
-- Goal: Add a financial computed column.
-- ============================================================================
GO
CREATE VIEW vw_EmployeeAnnualSalary AS
SELECT 
    EmployeeID, 
    FirstName, 
    LastName, 
    Salary, 
    Salary * 12 AS AnnualSalary
FROM Employees;
GO

PRINT '--- Verification for Exercise 3 ---';
SELECT * FROM vw_EmployeeAnnualSalary;


-- ============================================================================
-- Exercise 4: Add Multiple Computed Columns
-- Goal: Combine multiple computed columns in a single view.
-- ============================================================================
GO
CREATE VIEW vw_EmployeeReport AS
SELECT 
    e.EmployeeID,
    e.FirstName + ' ' + e.LastName AS FullName,
    d.DepartmentName,
    e.Salary * 12 AS AnnualSalary,
    (e.Salary * 12) * 0.10 AS Bonus
FROM Employees e
INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID;
GO

PRINT '--- Verification for Exercise 4 ---';
SELECT * FROM vw_EmployeeReport;
