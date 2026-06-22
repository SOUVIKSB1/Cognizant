-- ============================================================================
-- Week 1 Assignment: Employee Management System - Error Handling & Transactions
-- ============================================================================

-- Setup database tables
IF OBJECT_ID('AuditLog', 'U') IS NOT NULL DROP TABLE AuditLog;
IF OBJECT_ID('Employees', 'U') IS NOT NULL DROP TABLE Employees;
IF OBJECT_ID('Departments', 'U') IS NOT NULL DROP TABLE Departments;

CREATE TABLE Departments ( 
    DepartmentID INT PRIMARY KEY, 
    DepartmentName VARCHAR(100) NOT NULL 
); 

CREATE TABLE Employees ( 
    EmployeeID INT PRIMARY KEY, 
    FirstName VARCHAR(50), 
    LastName VARCHAR(50), 
    Email VARCHAR(100) UNIQUE, 
    Salary DECIMAL(10, 2), 
    DepartmentID INT, 
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID) 
); 

CREATE TABLE AuditLog ( 
    LogID INT IDENTITY(1,1) PRIMARY KEY, 
    Action VARCHAR(100), 
    ErrorMessage VARCHAR(4000), 
    ActionDate DATETIME DEFAULT GETDATE() 
); 

-- Populate Departments
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'IT'),
(3, 'Finance');
GO

-- ============================================================================
-- Question 1 & 2 & 3 & 6: AddEmployee Stored Procedure with Error Handling
-- Goal: Demonstrate:
--   - Basic TRY...CATCH and logging to AuditLog (Q1)
--   - THROW to propagate errors (Q2)
--   - RAISERROR for custom salary rules (Q3)
--   - Dynamic RAISERROR based on Salary severity levels (Q6)
-- ============================================================================
GO
CREATE OR ALTER PROCEDURE AddEmployee
    @EmployeeID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @Salary DECIMAL(10, 2),
    @DepartmentID INT
AS
BEGIN
    BEGIN TRY
        -- Check negative salary (Q6)
        IF @Salary < 0
        BEGIN
            RAISERROR('Salary cannot be negative. Salary value provided: %f', 16, 1, @Salary);
        END

        -- Check low salary warning (Q6 - Severity 10 is a warning, doesn't jump to CATCH block automatically but can be flagged)
        IF @Salary < 1000
        BEGIN
            -- Severity 10 is informational, will not abort execution
            RAISERROR('Warning: Salary is below the standard minimum of $1000.', 10, 1);
        END

        -- Check custom rule: Salary must be greater than zero (Q3)
        IF @Salary = 0
        BEGIN
            RAISERROR('Salary must be greater than zero.', 16, 2);
        END

        -- Attempt to insert employee
        INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, Salary, DepartmentID)
        VALUES (@EmployeeID, @FirstName, @LastName, @Email, @Salary, @DepartmentID);

        PRINT 'Employee inserted successfully.';
    END TRY
    BEGIN CATCH
        -- Log the error into AuditLog (Q1)
        INSERT INTO AuditLog (Action, ErrorMessage)
        VALUES ('INSERT_EMPLOYEE_FAIL', ERROR_MESSAGE());

        -- Re-raise the error using THROW (Q2)
        -- THROW syntax: THROW [error_number, message, state];
        -- If no arguments are provided, it re-throws the current error.
        THROW;
    END CATCH
END;
GO

PRINT '--- Testing AddEmployee (Duplicate Email Error) ---';
-- First insert succeeds
EXEC AddEmployee 1, 'John', 'Doe', 'john.doe@example.com', 5000.00, 1;

-- Second insert with duplicate email (should fail, log to AuditLog, and THROW)
BEGIN TRY
    EXEC AddEmployee 2, 'Johnny', 'Doe', 'john.doe@example.com', 6000.00, 1;
END TRY
BEGIN CATCH
    PRINT 'Caught Error in caller: ' + ERROR_MESSAGE();
END CATCH;

-- Verify AuditLog
SELECT * FROM AuditLog;
GO

PRINT '--- Testing AddEmployee (Salary <= 0 Error) ---';
BEGIN TRY
    EXEC AddEmployee 3, 'Jane', 'Smith', 'jane@example.com', 0, 1;
END TRY
BEGIN CATCH
    PRINT 'Caught Error in caller: ' + ERROR_MESSAGE();
END CATCH;
GO


-- ============================================================================
-- Question 4: Nested TRY...CATCH with RAISERROR
-- Goal: Transfer employee to a department. If department doesn't exist, raise
-- custom error. Use nested TRY...CATCH to log error and re-raise.
-- ============================================================================
GO
CREATE OR ALTER PROCEDURE TransferEmployee
    @EmployeeID INT,
    @NewDepartmentID INT
AS
BEGIN
    BEGIN TRY
        -- Outer Try Block
        BEGIN TRY
            -- Inner Try Block: Validate department
            IF NOT EXISTS (SELECT 1 FROM Departments WHERE DepartmentID = @NewDepartmentID)
            BEGIN
                RAISERROR('Target Department ID %d does not exist.', 16, 1, @NewDepartmentID);
            END

            UPDATE Employees
            SET DepartmentID = @NewDepartmentID
            WHERE EmployeeID = @EmployeeID;

            IF @@ROWCOUNT = 0
            BEGIN
                RAISERROR('Employee ID %d not found.', 16, 2, @EmployeeID);
            END
            
            PRINT 'Employee transferred successfully.';
        END TRY
        BEGIN CATCH
            -- Inner Catch Block: Log error locally
            INSERT INTO AuditLog (Action, ErrorMessage)
            VALUES ('TRANSFER_EMPLOYEE_INNER_FAIL', 'Inner Catch: ' + ERROR_MESSAGE());
            
            -- Re-raise error to outer catch block
            THROW;
        END CATCH
    END TRY
    BEGIN CATCH
        -- Outer Catch Block: Final cleanup or log
        INSERT INTO AuditLog (Action, ErrorMessage)
        VALUES ('TRANSFER_EMPLOYEE_OUTER_FAIL', 'Outer Catch: ' + ERROR_MESSAGE());
        
        -- Propagate error to application
        THROW;
    END CATCH
END;
GO

PRINT '--- Testing TransferEmployee (Invalid Department) ---';
BEGIN TRY
    EXEC TransferEmployee @EmployeeID = 1, @NewDepartmentID = 999;
END TRY
BEGIN CATCH
    PRINT 'Caught Error in caller: ' + ERROR_MESSAGE();
END CATCH;

SELECT * FROM AuditLog;
GO


-- ============================================================================
-- Question 5: Logging All Errors in a Transaction
-- Goal: Wrap multiple inserts in a transaction. Rollback and log if any fails.
-- ============================================================================
GO
CREATE OR ALTER PROCEDURE BatchInsertEmployees
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        -- Insert 1: Valid Employee
        INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, Salary, DepartmentID)
        VALUES (10, 'Alice', 'Wonder', 'alice@example.com', 4500.00, 1);

        -- Insert 2: Valid Employee
        INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, Salary, DepartmentID)
        VALUES (11, 'Bob', 'Builder', 'bob@example.com', 5200.00, 2);

        -- Insert 3: INVALID Employee (Constraint violation - Department 99 does not exist)
        INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, Salary, DepartmentID)
        VALUES (12, 'Charlie', 'Brown', 'charlie@example.com', 3800.00, 99);

        COMMIT TRANSACTION;
        PRINT 'Batch inserts committed successfully.';
    END TRY
    BEGIN CATCH
        -- Rollback all inserts in transaction
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Log error to AuditLog
        INSERT INTO AuditLog (Action, ErrorMessage)
        VALUES ('BATCH_INSERT_FAIL', 'Transaction rolled back. Error: ' + ERROR_MESSAGE());

        PRINT 'Batch insert failed. Transaction rolled back and error logged.';
    END CATCH
END;
GO

PRINT '--- Testing BatchInsertEmployees (Expected failure and rollback) ---';
EXEC BatchInsertEmployees;

-- Verify that no new employees (ID 10, 11) were inserted due to rollback
SELECT * FROM Employees WHERE EmployeeID IN (10, 11, 12);
SELECT * FROM AuditLog;
GO
