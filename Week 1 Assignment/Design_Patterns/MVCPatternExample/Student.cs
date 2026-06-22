namespace MVCPatternExample
{
    public class Student
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Grade { get; set; }

        public Student(string id, string name, string grade)
        {
            Id = id;
            Name = name;
            Grade = grade;
        }
    }
}
