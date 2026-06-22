using System;

namespace EmployeeManagementSystem
{
    public class EmployeeRegistry
    {
        private readonly Employee[] _employees;
        private int _count;

        public EmployeeRegistry(int capacity)
        {
            _employees = new Employee[capacity];
            _count = 0;
        }

        // Add Employee
        public bool AddEmployee(Employee employee)
        {
            if (employee == null) return false;
            if (_count >= _employees.Length)
            {
                Console.WriteLine("Error: Registry capacity reached. Cannot add more employees.");
                return false;
            }

            // Check if already exists
            for (int i = 0; i < _count; i++)
            {
                if (_employees[i].EmployeeId == employee.EmployeeId)
                {
                    Console.WriteLine($"Error: Employee with ID {employee.EmployeeId} already exists.");
                    return false;
                }
            }

            _employees[_count] = employee;
            _count++;
            return true;
        }

        // Search Employee
        public Employee SearchEmployee(string employeeId)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_employees[i].EmployeeId.Equals(employeeId, StringComparison.OrdinalIgnoreCase))
                {
                    return _employees[i];
                }
            }
            return null;
        }

        // Traverse Employees
        public void TraverseEmployees()
        {
            if (_count == 0)
            {
                Console.WriteLine("No employees in registry.");
                return;
            }
            Console.WriteLine("\n--- Employee Registry List ---");
            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine(_employees[i]);
            }
            Console.WriteLine("------------------------------\n");
        }

        // Delete Employee
        public bool DeleteEmployee(string employeeId)
        {
            int foundIndex = -1;
            for (int i = 0; i < _count; i++)
            {
                if (_employees[i].EmployeeId.Equals(employeeId, StringComparison.OrdinalIgnoreCase))
                {
                    foundIndex = i;
                    break;
                }
            }

            if (foundIndex == -1)
            {
                Console.WriteLine($"Error: Employee with ID {employeeId} not found.");
                return false;
            }

            // Shift elements to the left to maintain contiguity
            for (int i = foundIndex; i < _count - 1; i++)
            {
                _employees[i] = _employees[i + 1];
            }

            // Clear the last element and decrement count
            _employees[_count - 1] = null;
            _count--;
            return true;
        }
    }
}
