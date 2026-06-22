using System;

namespace EmployeeManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Employee Management System Test");
            Console.WriteLine("========================================");

            EmployeeRegistry registry = new EmployeeRegistry(5);

            // 1. Add Employees
            Console.WriteLine("Adding employees...");
            registry.AddEmployee(new Employee("E001", "John Doe", "Software Engineer", 75000));
            registry.AddEmployee(new Employee("E002", "Jane Smith", "Project Manager", 85000));
            registry.AddEmployee(new Employee("E003", "Bob Johnson", "QA Analyst", 60000));
            registry.AddEmployee(new Employee("E004", "Alice Brown", "HR Specialist", 65000));

            registry.TraverseEmployees();

            // 2. Search Employee
            string searchId = "E002";
            Console.WriteLine($"Searching for employee with ID {searchId}...");
            Employee found = registry.SearchEmployee(searchId);
            if (found != null)
            {
                Console.WriteLine($"Found: {found}");
            }
            else
            {
                Console.WriteLine($"Employee with ID {searchId} not found.");
            }

            // 3. Delete Employee
            string deleteId = "E003";
            Console.WriteLine($"\nDeleting employee with ID {deleteId}...");
            registry.DeleteEmployee(deleteId);

            registry.TraverseEmployees();

            // 4. Attempt to add beyond capacity to test limits
            Console.WriteLine("Adding two more employees to test capacity limit (max 5)...");
            registry.AddEmployee(new Employee("E005", "Charlie Green", "UX Designer", 70000));
            registry.AddEmployee(new Employee("E006", "David White", "DevOps Engineer", 80000));

            registry.TraverseEmployees();
        }
    }
}
