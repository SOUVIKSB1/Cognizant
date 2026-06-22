using System;

namespace MVCPatternExample
{
    public class StudentView
    {
        public void DisplayStudentDetails(string studentName, string studentId, string studentGrade)
        {
            Console.WriteLine("\n--- Student Records Display ---");
            Console.WriteLine($"  ID:    {studentId}");
            Console.WriteLine($"  Name:  {studentName}");
            Console.WriteLine($"  Grade: {studentGrade}");
            Console.WriteLine("-------------------------------\n");
        }
    }
}
