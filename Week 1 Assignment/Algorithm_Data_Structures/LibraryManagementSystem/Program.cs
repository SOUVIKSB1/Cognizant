using System;
using System.Linq;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Library Management System Search Test");
            Console.WriteLine("========================================");

            // 1. Initial Unsorted Book List
            Book[] books = new Book[]
            {
                new Book("B003", "The Great Gatsby", "F. Scott Fitzgerald"),
                new Book("B001", "To Kill a Mockingbird", "Harper Lee"),
                new Book("B005", "1984", "George Orwell"),
                new Book("B002", "Moby Dick", "Herman Melville"),
                new Book("B004", "Pride and Prejudice", "Jane Austen")
            };

            Console.WriteLine("Unsorted Books in Library:");
            foreach (var b in books)
            {
                Console.WriteLine(b);
            }

            // 2. Linear Search
            string searchTitle = "1984";
            Console.WriteLine($"\nSearching for '{searchTitle}' using Linear Search...");
            Book resultLinear = Library.LinearSearchByTitle(books, searchTitle);
            if (resultLinear != null)
            {
                Console.WriteLine($"Found: {resultLinear}");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }

            // 3. Sort for Binary Search
            Console.WriteLine("\nSorting books by title for Binary Search...");
            Book[] sortedBooks = books.OrderBy(b => b.Title).ToArray();
            Console.WriteLine("Sorted Books in Library:");
            foreach (var b in sortedBooks)
            {
                Console.WriteLine(b);
            }

            // 4. Binary Search
            Console.WriteLine($"\nSearching for '{searchTitle}' using Binary Search...");
            Book resultBinary = Library.BinarySearchByTitle(sortedBooks, searchTitle);
            if (resultBinary != null)
            {
                Console.WriteLine($"Found: {resultBinary}");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }

            // 5. Search for non-existent book
            string missingTitle = "The Catcher in the Rye";
            Console.WriteLine($"\nSearching for non-existent '{missingTitle}' using Binary Search...");
            Book resultMissing = Library.BinarySearchByTitle(sortedBooks, missingTitle);
            if (resultMissing != null)
            {
                Console.WriteLine($"Found: {resultMissing}");
            }
            else
            {
                Console.WriteLine($"'{missingTitle}' was not found.");
            }
        }
    }
}
