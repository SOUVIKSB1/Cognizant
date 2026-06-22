using System;

namespace TaskManagementSystem
{
    public class SinglyLinkedList
    {
        private class Node
        {
            public Task Data { get; }
            public Node Next { get; set; }

            public Node(Task task)
            {
                Data = task;
                Next = null;
            }
        }

        private Node _head;
        private Node _tail;

        public SinglyLinkedList()
        {
            _head = null;
            _tail = null;
        }

        // Add Task (Appends to the end of the list: O(1) using tail pointer)
        public void AddTask(Task task)
        {
            if (task == null) return;
            Node newNode = new Node(task);

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }
        }

        // Search Task by ID
        public Task SearchTask(string taskId)
        {
            Node current = _head;
            while (current != null)
            {
                if (current.Data.TaskId.Equals(taskId, StringComparison.OrdinalIgnoreCase))
                {
                    return current.Data;
                }
                current = current.Next;
            }
            return null;
        }

        // Traverse & Display Tasks
        public void TraverseTasks()
        {
            if (_head == null)
            {
                Console.WriteLine("Task list is empty.");
                return;
            }

            Console.WriteLine("\n--- Current Task List ---");
            Node current = _head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
            Console.WriteLine("-------------------------\n");
        }

        // Delete Task by ID
        public bool DeleteTask(string taskId)
        {
            if (_head == null) return false;

            // If head node contains the task
            if (_head.Data.TaskId.Equals(taskId, StringComparison.OrdinalIgnoreCase))
            {
                _head = _head.Next;
                if (_head == null)
                {
                    _tail = null; // List is now empty
                }
                return true;
            }

            Node prev = _head;
            Node current = _head.Next;

            while (current != null)
            {
                if (current.Data.TaskId.Equals(taskId, StringComparison.OrdinalIgnoreCase))
                {
                    prev.Next = current.Next;
                    
                    // If we deleted the tail node, update tail reference
                    if (current == _tail)
                    {
                        _tail = prev;
                    }
                    return true;
                }
                prev = current;
                current = current.Next;
            }

            Console.WriteLine($"Error: Task with ID {taskId} not found.");
            return false;
        }
    }
}
