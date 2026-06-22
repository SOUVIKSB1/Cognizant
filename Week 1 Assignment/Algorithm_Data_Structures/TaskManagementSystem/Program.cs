using System;

namespace TaskManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Task Management System Test");
            Console.WriteLine("========================================");

            SinglyLinkedList taskList = new SinglyLinkedList();

            // 1. Add Tasks
            Console.WriteLine("Adding tasks...");
            taskList.AddTask(new Task("T001", "Design Database Schema", "Completed"));
            taskList.AddTask(new Task("T002", "Implement API Endpoints", "In Progress"));
            taskList.AddTask(new Task("T003", "Write Unit Tests", "Pending"));
            taskList.AddTask(new Task("T004", "Configure CI/CD Pipelines", "Pending"));

            taskList.TraverseTasks();

            // 2. Search Task
            string searchId = "T002";
            Console.WriteLine($"Searching for task with ID {searchId}...");
            Task found = taskList.SearchTask(searchId);
            if (found != null)
            {
                Console.WriteLine($"Found: {found}");
            }
            else
            {
                Console.WriteLine($"Task with ID {searchId} not found.");
            }

            // 3. Delete Task
            string deleteId = "T003";
            Console.WriteLine($"\nDeleting task with ID {deleteId}...");
            taskList.DeleteTask(deleteId);

            taskList.TraverseTasks();

            // 4. Delete the head node to show list robustness
            Console.WriteLine("Deleting head task (T001)...");
            taskList.DeleteTask("T001");

            taskList.TraverseTasks();
        }
    }
}
