-- ============================================================================
-- Week 1 Assignment: Employee Management System - Functions Exercises
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
(3, 'Bob', 'Johnson', 3, 5500.00, '2021-07-01');

-- Clean up any existing functions before creating
IF OBJECT_ID('dbo.fn_CalculateTotalCompensation', 'FN') IS NOT NULL DROP FUNCTION dbo.fn_CalculateTotalCompensation;
IF OBJECT_ID('dbo.fn_CalculateBonus', 'FN') IS NOT NULL DROP FUNCTION dbo.fn_CalculateBonus;
IF OBJECT_ID('dbo.fn_CalculateAnnualSalary', 'FN') IS NOT NULL DROP FUNCTION dbo.fn_CalculateAnnualSalary;
IF OBJECT_ID('dbo.fn_GetEmployeesByDepartment', 'IF') IS NOT NULL DROP FUNCTION dbo.fn_GetEmployeesByDepartment;
IF OBJECT_ID('dbo.fn_GetEmployeesByDepartment', 'TF') IS NOT NULL DROP FUNCTION dbo.fn_GetEmployeesByDepartment;
GO

-- ============================================================================
-- Exercise 1: Create a Scalar Function
-- Goal: Calculate annual salary of an employee.
-- ============================================================================
CREATE FUNCTION fn_CalculateAnnualSalary (
    @Salary DECIMAL(10,2)
)
RETURNS DECIMAL(12,2)
AS
BEGIN
    RETURN @Salary * 12;
END;
GO

PRINT '--- Testing fn_CalculateAnnualSalary ---';
SELECT EmployeeID, FirstName, Salary, dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary 
FROM Employees;
GO


-- ============================================================================
-- Exercise 2: Create a Table-Valued Function
-- Goal: Return employees in a specific department.
-- ============================================================================
CREATE FUNCTION fn_GetEmployeesByDepartment (
    @DepartmentID INT
)
RETURNS TABLE
AS
RETURN (
    SELECT EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate
    FROM Employees
    WHERE DepartmentID = @DepartmentID
);
GO

PRINT '--- Testing fn_GetEmployeesByDepartment (IT Dept: 2) ---';
SELECT * FROM dbo.fn_GetEmployeesByDepartment(2);
GO


-- ============================================================================
-- Exercise 3: Create a User-Defined Function (Bonus)
-- Goal: Calculate the 10% bonus for an employee.
-- ============================================================================
CREATE FUNCTION fn_CalculateBonus (
    @Salary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Salary * 0.10;
END;
GO

PRINT '--- Testing fn_CalculateBonus (10%) ---';
SELECT EmployeeID, FirstName, Salary, dbo.fn_CalculateBonus(Salary) AS Bonus
FROM Employees;
GO


-- ============================================================================
-- Exercise 4: Modify a User-Defined Function
-- Goal: Alter the fn_CalculateBonus function to return Salary * 0.15.
-- ============================================================================
ALTER FUNCTION fn_CalculateBonus (
    @Salary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Salary * 0.15;
END;
GO

PRINT '--- Testing Modified fn_CalculateBonus (15%) ---';
SELECT EmployeeID, FirstName, Salary, dbo.fn_CalculateBonus(Salary) AS Bonus
FROM Employees;
GO


-- ============================================================================
-- Exercise 5: Delete a User-Defined Function
-- Goal: Drop the fn_CalculateBonus function.
-- ============================================================================
PRINT '--- Dropping fn_CalculateBonus ---';
DROP FUNCTION fn_CalculateBonus;
GO

-- Verify it has been deleted
IF OBJECT_ID('dbo.fn_CalculateBonus', 'FN') IS NULL
    PRINT 'Verification: fn_CalculateBonus successfully deleted.';
ELSE
    PRINT 'Verification: fn_CalculateBonus still exists.';
GO


-- ============================================================================
-- Exercise 6: Execute a User-Defined Function
-- Goal: Use fn_CalculateAnnualSalary to calculate annual salary.
-- ============================================================================
PRINT '--- Exercise 6: Calculating Annual Salary for All Employees ---';
SELECT EmployeeID, FirstName, LastName, dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM Employees;
GO


-- ============================================================================
-- Exercise 7: Return Data from a Scalar Function (Single Employee)
-- Goal: Return the annual salary for EmployeeID = 1.
-- ============================================================================
PRINT '--- Exercise 7: Annual Salary for EmployeeID = 1 ---';
SELECT dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalaryForEmp1
FROM Employees
WHERE EmployeeID = 1;
GO


-- ============================================================================
-- Exercise 8: Return Data from a Table-Valued Function (Finance Department)
-- Goal: Return employees from the Finance department (ID = 3).
-- ============================================================================
PRINT '--- Exercise 8: Employees from Finance (Dept 3) ---';
SELECT * FROM dbo.fn_GetEmployeesByDepartment(3);
GO


-- ============================================================================
-- Exercise 9: Create a Nested User-Defined Function
-- Goal: Create fn_CalculateTotalCompensation combining AnnualSalary and Bonus.
-- Note: Since we dropped fn_CalculateBonus in Ex 5, we recreate it here to allow compilation.
-- ============================================================================
PRINT '--- Recreating fn_CalculateBonus (10%) for Nested function test ---';
GO
CREATE FUNCTION fn_CalculateBonus (
    @Salary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Salary * 0.10;
END;
GO

CREATE FUNCTION fn_CalculateTotalCompensation (
    @Salary DECIMAL(10,2)
)
RETURNS DECIMAL(12,2)
AS
BEGIN
    DECLARE @AnnualSalary DECIMAL(12,2);
    DECLARE @Bonus DECIMAL(10,2);
    
    SET @AnnualSalary = dbo.fn_CalculateAnnualSalary(@Salary);
    SET @Bonus = dbo.fn_CalculateBonus(@Salary);
    
    RETURN @AnnualSalary + @Bonus;
END;
GO

PRINT '--- Testing fn_CalculateTotalCompensation ---';
SELECT EmployeeID, FirstName, Salary, 
       dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary, 
       dbo.fn_CalculateBonus(Salary) AS Bonus,
       dbo.fn_CalculateTotalCompensation(Salary) AS TotalCompensation
FROM Employees;
GO


-- ============================================================================
-- Exercise 10: Modify a Nested User-Defined Function
-- Goal: Modify the fn_CalculateTotalCompensation function to use modified bonus.
-- We alter fn_CalculateBonus to 15% and modify/re-verify TotalCompensation.
-- ============================================================================
PRINT '--- Altering fn_CalculateBonus to 15% ---';
GO
ALTER FUNCTION fn_CalculateBonus (
    @Salary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Salary * 0.15;
END;
GO

PRINT '--- Testing fn_CalculateTotalCompensation after Bonus alteration ---';
SELECT EmployeeID, FirstName, Salary, 
       dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary, 
       dbo.fn_CalculateBonus(Salary) AS Bonus,
       dbo.fn_CalculateTotalCompensation(Salary) AS TotalCompensation
FROM Employees;
GO
