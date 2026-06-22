-- ============================================================================
-- Week 1 Assignment: Employee Management System - SQL Cursors Exercises
-- ============================================================================

-- Setup database tables and insert sample data
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
    Salary DECIMAL(10,2),
    JoinDate DATE
);

-- Insert Sample Data
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'IT'),
(3, 'Finance');

INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'),
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'),
(3, 'Bob', 'Johnson', 3, 5500.00, '2021-07-30');
GO

-- ============================================================================
-- Exercise 1: Create a Cursor
-- Goal: Create a cursor to iterate over all employees and print their details.
-- ============================================================================

PRINT '--- Running Exercise 1: Basic Cursor Loop ---';

-- Declare variables to store fetched values
DECLARE @EmpID INT;
DECLARE @FName VARCHAR(50);
DECLARE @LName VARCHAR(50);
DECLARE @Sal DECIMAL(10,2);
DECLARE @JDate DATE;
DECLARE @DeptID INT;

-- 1. Declare the cursor
DECLARE emp_cursor CURSOR FOR
SELECT EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate
FROM Employees;

-- 2. Open the cursor
OPEN emp_cursor;

-- 3. Fetch the first row
FETCH NEXT FROM emp_cursor 
INTO @EmpID, @FName, @LName, @DeptID, @Sal, @JDate;

-- 4. Loop through until the end of the cursor
WHILE @@FETCH_STATUS = 0
BEGIN
    -- Print employee details
    PRINT 'Employee ID: ' + CAST(@EmpID AS VARCHAR(5)) + 
          ', Name: ' + @FName + ' ' + @LName + 
          ', Dept ID: ' + CAST(@DeptID AS VARCHAR(5)) + 
          ', Salary: $' + CAST(@Sal AS VARCHAR(10)) + 
          ', Joined: ' + CAST(@JDate AS VARCHAR(15));
          
    -- Fetch the next row
    FETCH NEXT FROM emp_cursor 
    INTO @EmpID, @FName, @LName, @DeptID, @Sal, @JDate;
END;

-- 5. Close the cursor
CLOSE emp_cursor;

-- 6. Deallocate the cursor
DEALLOCATE emp_cursor;
GO


-- ============================================================================
-- Exercise 2: Types of Cursors
-- Goal: Understand different types of cursors in SQL Server.
-- ============================================================================

PRINT '--- Exercise 2: Types of Cursors (Declarations and Comparison) ---';

-- 1. STATIC Cursor
-- The membership, order, and values in the result set are fixed when the cursor is opened.
-- It works on a copy of the data in tempdb; changes made by other users are not visible.
DECLARE static_emp_cursor CURSOR STATIC FOR
SELECT EmployeeID, FirstName, LastName, Salary FROM Employees;

-- 2. DYNAMIC Cursor
-- Reflects all changes made to the rows in their data source as you scroll.
-- The membership, order, and values of the rows can change on each fetch.
DECLARE dynamic_emp_cursor CURSOR DYNAMIC FOR
SELECT EmployeeID, FirstName, LastName, Salary FROM Employees;

-- 3. FORWARD_ONLY Cursor
-- Can only scroll forward from the first to the last row.
-- Changes made by others are visible as the rows are fetched (unless STATIC is specified).
-- This is the default cursor type in SQL Server if none are specified.
DECLARE forward_only_emp_cursor CURSOR FORWARD_ONLY FOR
SELECT EmployeeID, FirstName, LastName, Salary FROM Employees;

-- 4. KEYSET-driven Cursor
-- The membership and order of rows are fixed when the cursor is opened.
-- It is controlled by a set of unique identifiers (keys) built in tempdb.
-- Changes to data values made by other users are visible, but inserts are not.
DECLARE keyset_emp_cursor CURSOR KEYSET FOR
SELECT EmployeeID, FirstName, LastName, Salary FROM Employees;


-- ============================================================================
-- Summary Comparison of Cursor Types
-- ============================================================================
/*
+--------------+------------------+------------------+-----------------------+
| Cursor Type  | Scroll Direction | Visible Changes  | Performance (Cost)    |
+--------------+------------------+------------------+-----------------------+
| FORWARD_ONLY | Only Forward     | Yes              | Lowest overhead       |
| STATIC       | Any Direction    | No               | Copy in tempdb (High) |
| KEYSET       | Any Direction    | Data Updates Yes | Mid-to-High overhead  |
| DYNAMIC      | Any Direction    | Yes (all changes)| Highest overhead      |
+--------------+------------------+------------------+-----------------------+
*/
GO
