namespace TaskManagementSystem
{
    public class Task
    {
        public string TaskId { get; set; }
        public string TaskName { get; set; }
        public string Status { get; set; }

        public Task(string taskId, string taskName, string status)
        {
            TaskId = taskId;
            TaskName = taskName;
            Status = status;
        }

        public override string ToString()
        {
            return $"ID: {TaskId} | Task Name: {TaskName} | Status: {Status}";
        }
    }
}
