using System;

namespace MVCPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("MVC Pattern Example");
            Console.WriteLine("========================================");

            // 1. Fetch student record from database/source (simulated)
            Student model = RetrieveStudentFromDatabase();

            // 2. Create a view to render details
            StudentView view = new StudentView();

            // 3. Initialize controller
            StudentController controller = new StudentController(model, view);

            // 4. Initial rendering
            Console.WriteLine("Initial details:");
            controller.UpdateView();

            // 5. Update model data through controller
            Console.WriteLine("Updating student name and grade...");
            controller.StudentName = "Souvik Sen";
            controller.StudentGrade = "A+";

            // 6. Render updated details
            Console.WriteLine("Updated details:");
            controller.UpdateView();

            Console.WriteLine("MVC Pattern demonstration completed.");
        }

        private static Student RetrieveStudentFromDatabase()
        {
            return new Student("S101", "John Doe", "B");
        }
    }
}
