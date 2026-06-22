-- ============================================================================
-- Week 1 Assignment: Employee Management System - Triggers Exercises
-- ============================================================================

-- Setup database tables and insert sample data
IF OBJECT_ID('EmployeeChanges', 'U') IS NOT NULL DROP TABLE EmployeeChanges;
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
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing');

INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
(1, 'John', 'Doe', 1, 5000.00, '2022-01-15'),
(2, 'Jane', 'Smith', 2, 6000.00, '2021-03-22'),
(3, 'Michael', 'Johnson', 3, 7000.00, '2020-07-30'),
(4, 'Emily', 'Davis', 4, 5500.00, '2019-11-05');
GO

-- ============================================================================
-- Exercise 1: Create an After Trigger
-- Goal: Log salary changes in the Employees table.
-- ============================================================================

-- 1. Create audit log table
CREATE TABLE EmployeeChanges (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID INT,
    OldSalary DECIMAL(10,2),
    NewSalary DECIMAL(10,2),
    ChangeDate DATETIME DEFAULT GETDATE(),
    Action VARCHAR(50)
);
GO

-- 2. Create AFTER UPDATE trigger to log salary changes
CREATE TRIGGER trg_LogEmployeeSalaryChange
ON Employees
AFTER UPDATE
AS
BEGIN
    -- Check if Salary column was updated
    IF UPDATE(Salary)
    BEGIN
        INSERT INTO EmployeeChanges (EmployeeID, OldSalary, NewSalary, Action)
        SELECT 
            i.EmployeeID,
            d.Salary AS OldSalary,
            i.Salary AS NewSalary,
            'SALARY_UPDATE'
        FROM inserted i
        INNER JOIN deleted d ON i.EmployeeID = d.EmployeeID;
    END
END;
GO

PRINT '--- Testing AFTER UPDATE Trigger (Updating Jane Smith Salary from 6000 to 6500) ---';
UPDATE Employees SET Salary = 6500.00 WHERE EmployeeID = 2;

-- Check changes table
SELECT * FROM EmployeeChanges;
GO


-- ============================================================================
-- Exercise 2: Create an Instead of Trigger
-- Goal: Prevent deletions from the Employees table and raise an error.
-- ============================================================================
CREATE TRIGGER trg_PreventEmployeeDelete
ON Employees
INSTEAD OF DELETE
AS
BEGIN
    RAISERROR('Employee deletions are not allowed for auditing purposes. You can only set status or terminate.', 16, 1);
END;
GO

PRINT '--- Testing INSTEAD OF DELETE Trigger (Attempting to delete John Doe) ---';
BEGIN TRY
    DELETE FROM Employees WHERE EmployeeID = 1;
END TRY
BEGIN CATCH
    PRINT 'Error Caught: ' + ERROR_MESSAGE();
END CATCH;
GO


-- ============================================================================
-- Exercise 3: Create a Logon Trigger
-- Goal: Restrict database login during maintenance hours (2 AM to 3 AM).
-- ============================================================================
-- Note: LOGON triggers are defined ON ALL SERVER (or ON DATABASE on SQL Azure).
-- Below is the script to create a LOGON trigger. It is commented out by default
-- to avoid locks on server/local environment during test runs.
/*
CREATE TRIGGER trg_RestrictLogonDuringMaintenance
ON ALL SERVER
WITH EXECUTE AS 'sa'
FOR LOGON
AS
BEGIN
    DECLARE @CurrentHour INT = DATEPART(HOUR, GETDATE());
    -- Restrict logins between 2:00 AM and 3:00 AM
    IF @CurrentHour = 2
    BEGIN
        ROLLBACK; -- Deny the connection
    END
END;
*/
GO


-- ============================================================================
-- Exercise 4: Modify a Trigger using SSMS
-- Goal: Explain steps to modify a trigger using SSMS, and provide ALTER trigger code.
-- ============================================================================
/*
--- SSMS Modification Steps:
1. Open SSMS and connect to the database.
2. In Object Explorer, expand Databases -> YourDatabase -> Tables -> Employees -> Triggers.
3. Right-click 'trg_LogEmployeeSalaryChange' and select "Modify" or "Script Trigger as -> ALTER To -> New Query Editor Window".
4. Modify the trigger logic (e.g. log the user who made the change).
5. Execute the query to apply the changes.
*/

-- SQL equivalent of altering the trigger:
GO
ALTER TRIGGER trg_LogEmployeeSalaryChange
ON Employees
AFTER UPDATE
AS
BEGIN
    IF UPDATE(Salary)
    BEGIN
        INSERT INTO EmployeeChanges (EmployeeID, OldSalary, NewSalary, Action)
        SELECT 
            i.EmployeeID,
            d.Salary,
            i.Salary,
            'SALARY_UPDATE_BY_' + SYSTEM_USER
        FROM inserted i
        INNER JOIN deleted d ON i.EmployeeID = d.EmployeeID;
    END
END;
GO

PRINT '--- Testing Altered AFTER UPDATE Trigger (Jane Smith Salary to 6800) ---';
UPDATE Employees SET Salary = 6800.00 WHERE EmployeeID = 2;
SELECT * FROM EmployeeChanges;
GO


-- ============================================================================
-- Exercise 5: Delete a Trigger
-- Goal: Delete an existing trigger from the Employees table.
-- ============================================================================
PRINT '--- Dropping trg_PreventEmployeeDelete trigger ---';
IF OBJECT_ID('trg_PreventEmployeeDelete', 'TR') IS NOT NULL
    DROP TRIGGER trg_PreventEmployeeDelete;
GO


-- ============================================================================
-- Exercise 6: Create a Trigger to Update a Computed Column
-- Goal: Trigger-calculated AnnualSalary update.
-- ============================================================================

-- 1. Add AnnualSalary column to Employees table
ALTER TABLE Employees ADD AnnualSalary DECIMAL(12,2);
GO

-- Populate initial values
UPDATE Employees SET AnnualSalary = Salary * 12;
GO

-- 2. Create trigger to compute and update AnnualSalary on Salary update
CREATE TRIGGER trg_UpdateAnnualSalary
ON Employees
AFTER INSERT, UPDATE
AS
BEGIN
    -- Prevent recursive trigger calls
    IF TRIGGER_NESTLEVEL() > 1 RETURN;

    -- Update AnnualSalary column in Employees based on new Salary
    UPDATE e
    SET e.AnnualSalary = e.Salary * 12
    FROM Employees e
    INNER JOIN inserted i ON e.EmployeeID = i.EmployeeID;
END;
GO

PRINT '--- Testing trigger computed column update ---';
SELECT EmployeeID, FirstName, Salary, AnnualSalary FROM Employees WHERE EmployeeID = 1;

PRINT '--- Updating John Doe salary to 5200 (Expected AnnualSalary: 62400) ---';
UPDATE Employees SET Salary = 5200.00 WHERE EmployeeID = 1;

SELECT EmployeeID, FirstName, Salary, AnnualSalary FROM Employees WHERE EmployeeID = 1;
GO
