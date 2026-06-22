-- ============================================================================
-- Week 1 Assignment: Employee Management System - Stored Procedures
-- ============================================================================

-- Setup database tables and insert sample data
IF OBJECT_ID('Employees', 'U') IS NOT NULL DROP TABLE Employees;
IF OBJECT_ID('Departments', 'U') IS NOT NULL DROP TABLE Departments;

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

-- Note: We use IDENTITY(1,1) for EmployeeID so that sp_InsertEmployee works without passing ID
CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);

-- Insert Sample Data
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing');

INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
('John', 'Doe', 1, 5000.00, '2020-01-15'),
('Jane', 'Smith', 2, 6000.00, '2019-03-22'),
('Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
('Emily', 'Davis', 4, 5500.00, '2021-11-05');

-- ============================================================================
-- Exercise 1: Create a Stored Procedure
-- Goal: Create a stored procedure to retrieve employee details by department 
-- and another to insert employees.
-- ============================================================================
GO
CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT EmployeeID, FirstName, LastName, DepartmentID
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

CREATE PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;
GO

PRINT '--- Executing sp_GetEmployeesByDepartment (HR Dept: 1) ---';
EXEC sp_GetEmployeesByDepartment @DepartmentID = 1;


-- ============================================================================
-- Exercise 2: Modify a Stored Procedure
-- Goal: Modify the stored procedure to include employee salary in the result.
-- ============================================================================
GO
ALTER PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT EmployeeID, FirstName, LastName, DepartmentID, Salary
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

PRINT '--- Executing Modified sp_GetEmployeesByDepartment (Salary Included) ---';
EXEC sp_GetEmployeesByDepartment @DepartmentID = 1;


-- ============================================================================
-- Exercise 4: Execute a Stored Procedure
-- Goal: Execute sp_InsertEmployee and verify changes.
-- ============================================================================
PRINT '--- Executing sp_InsertEmployee ---';
EXEC sp_InsertEmployee 'Robert', 'Miller', 3, 6200.00, '2023-05-10';

PRINT '--- Checking Employees in IT (Dept 3) ---';
EXEC sp_GetEmployeesByDepartment @DepartmentID = 3;


-- ============================================================================
-- Exercise 3: Delete a Stored Procedure
-- Goal: Delete the stored procedure created in Exercise 1 (sp_GetEmployeesByDepartment).
-- ============================================================================
PRINT '--- Dropping sp_GetEmployeesByDepartment ---';
IF OBJECT_ID('sp_GetEmployeesByDepartment', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetEmployeesByDepartment;


-- ============================================================================
-- Exercise 5: Return Data from a Stored Procedure (Employee Count)
-- Goal: Create a stored procedure that returns the total number of employees.
-- ============================================================================
GO
CREATE PROCEDURE sp_GetEmployeeCountByDepartment
    @DepartmentID INT
AS
BEGIN
    DECLARE @Count INT;
    SELECT @Count = COUNT(*) FROM Employees WHERE DepartmentID = @DepartmentID;
    RETURN @Count;
END;
GO

PRINT '--- Executing sp_GetEmployeeCountByDepartment (IT Dept: 3) ---';
DECLARE @EmployeeCount INT;
EXEC @EmployeeCount = sp_GetEmployeeCountByDepartment @DepartmentID = 3;
PRINT 'Total employees in IT: ' + CAST(@EmployeeCount AS VARCHAR(10));


-- ============================================================================
-- Exercise 6: Use Output Parameters in a Stored Procedure
-- Goal: Return the total salary of a department using an output parameter.
-- ============================================================================
GO
CREATE PROCEDURE sp_GetTotalSalaryByDepartment
    @DepartmentID INT,
    @TotalSalary DECIMAL(10,2) OUTPUT
AS
BEGIN
    SELECT @TotalSalary = SUM(Salary) 
    FROM Employees 
    WHERE DepartmentID = @DepartmentID;
END;
GO

PRINT '--- Executing sp_GetTotalSalaryByDepartment (IT Dept: 3) ---';
DECLARE @ITTotalSalary DECIMAL(10,2);
EXEC sp_GetTotalSalaryByDepartment @DepartmentID = 3, @TotalSalary = @ITTotalSalary OUTPUT;
PRINT 'Total Salary in IT: $' + CAST(@ITTotalSalary AS VARCHAR(20));


-- ============================================================================
-- Exercise 7: Create a Stored Procedure with Multiple Parameters
-- Goal: Create a stored procedure to update employee salary.
-- ============================================================================
GO
CREATE PROCEDURE sp_UpdateEmployeeSalary
    @EmployeeID INT,
    @NewSalary DECIMAL(10,2)
AS
BEGIN
    UPDATE Employees
    SET Salary = @NewSalary
    WHERE EmployeeID = @EmployeeID;
END;
GO

PRINT '--- Updating Salary of EmployeeID = 1 ---';
EXEC sp_UpdateEmployeeSalary @EmployeeID = 1, @NewSalary = 5500.00;

SELECT EmployeeID, FirstName, LastName, Salary FROM Employees WHERE EmployeeID = 1;


-- ============================================================================
-- Exercise 8: Create a Stored Procedure with Conditional Logic
-- Goal: Give a bonus to employees based on their department.
-- ============================================================================
GO
CREATE PROCEDURE sp_GiveBonus
    @DepartmentID INT,
    @BonusAmount DECIMAL(10,2)
AS
BEGIN
    -- Business logic: check if the department exists
    IF EXISTS (SELECT 1 FROM Departments WHERE DepartmentID = @DepartmentID)
    BEGIN
        UPDATE Employees
        SET Salary = Salary + @BonusAmount
        WHERE DepartmentID = @DepartmentID;
        PRINT 'Bonus applied successfully to employees of Department ' + CAST(@DepartmentID AS VARCHAR(5));
    END
    ELSE
    BEGIN
        PRINT 'Department ID ' + CAST(@DepartmentID AS VARCHAR(5)) + ' does not exist. No bonus applied.';
    END
END;
GO

PRINT '--- Giving $500 Bonus to Department 1 ---';
EXEC sp_GiveBonus @DepartmentID = 1, @BonusAmount = 500.00;


-- ============================================================================
-- Exercise 9: Use Transactions in a Stored Procedure
-- Goal: Update employee salaries and use a transaction to ensure integrity.
-- ============================================================================
GO
CREATE PROCEDURE sp_UpdateEmployeeSalaryWithTransaction
    @EmployeeID INT,
    @NewSalary DECIMAL(10,2)
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        -- Check if employee exists
        IF NOT EXISTS (SELECT 1 FROM Employees WHERE EmployeeID = @EmployeeID)
        BEGIN
            THROW 50001, 'Employee ID does not exist.', 1;
        END

        UPDATE Employees
        SET Salary = @NewSalary
        WHERE EmployeeID = @EmployeeID;

        COMMIT TRANSACTION;
        PRINT 'Salary updated successfully with transaction.';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT 'Transaction Rolled Back due to error: ' + ERROR_MESSAGE();
    END CATCH
END;
GO

PRINT '--- Executing sp_UpdateEmployeeSalaryWithTransaction (Valid) ---';
EXEC sp_UpdateEmployeeSalaryWithTransaction 2, 6500.00;

PRINT '--- Executing sp_UpdateEmployeeSalaryWithTransaction (Invalid EmployeeID) ---';
EXEC sp_UpdateEmployeeSalaryWithTransaction 999, 6500.00;


-- ============================================================================
-- Exercise 10: Use Dynamic SQL in a Stored Procedure
-- Goal: Create a stored procedure that uses dynamic SQL to retrieve details.
-- ============================================================================
GO
CREATE PROCEDURE sp_GetEmployeesDynamicFilter
    @FilterColumn VARCHAR(50),
    @FilterValue VARCHAR(100)
    -- Parameter validation to protect against SQL Injection
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);
    DECLARE @ParmDefinition NVARCHAR(500);

    -- Whitelist the allowed columns to prevent SQL injection
    IF @FilterColumn NOT IN ('FirstName', 'LastName', 'DepartmentName')
    BEGIN
        RAISERROR('Invalid column name for filtering.', 16, 1);
        RETURN;
    END

    -- Build query dynamically
    IF @FilterColumn = 'DepartmentName'
    BEGIN
        SET @SQL = N'SELECT e.EmployeeID, e.FirstName, e.LastName, d.DepartmentName, e.Salary ' +
                   N'FROM Employees e ' +
                   N'INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID ' +
                   N'WHERE d.DepartmentName = @Value';
    END
    ELSE
    BEGIN
        SET @SQL = N'SELECT e.EmployeeID, e.FirstName, e.LastName, e.Salary ' +
                   N'FROM Employees e ' +
                   N'WHERE e.' + QUOTENAME(@FilterColumn) + N' = @Value';
    END

    SET @ParmDefinition = N'@Value VARCHAR(100)';
    EXEC sp_executesql @SQL, @ParmDefinition, @Value = @FilterValue;
END;
GO

PRINT '--- Executing Dynamic SQL Procedure (Filter by DepartmentName) ---';
EXEC sp_GetEmployeesDynamicFilter @FilterColumn = 'DepartmentName', @FilterValue = 'Finance';


-- ============================================================================
-- Exercise 11: Handle Errors in a Stored Procedure
-- Goal: Update employee salary with TRY...CATCH and custom error message.
-- ============================================================================
GO
CREATE PROCEDURE sp_UpdateEmployeeSalaryWithErrorHandling
    @EmployeeID INT,
    @NewSalary DECIMAL(10,2)
AS
BEGIN
    BEGIN TRY
        IF @NewSalary < 0
        BEGIN
            RAISERROR('Salary cannot be negative.', 16, 1);
        END

        UPDATE Employees
        SET Salary = @NewSalary
        WHERE EmployeeID = @EmployeeID;

        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR('Employee not found to update.', 16, 2);
        END
        
        PRINT 'Salary updated successfully.';
    END TRY
    BEGIN CATCH
        SELECT 
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_SEVERITY() AS ErrorSeverity,
            ERROR_STATE() AS ErrorState,
            'Error Occurred: ' + ERROR_MESSAGE() AS CustomErrorMessage;
    END CATCH
END;
GO

PRINT '--- Executing sp_UpdateEmployeeSalaryWithErrorHandling (Negative Salary) ---';
EXEC sp_UpdateEmployeeSalaryWithErrorHandling @EmployeeID = 1, @NewSalary = -500.00;
