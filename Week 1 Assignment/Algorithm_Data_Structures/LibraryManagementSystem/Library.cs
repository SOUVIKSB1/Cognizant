using System;

namespace LibraryManagementSystem
{
    public static class Library
    {
        // Linear Search by Title (returns Book or null)
        public static Book LinearSearchByTitle(Book[] books, string title)
        {
            if (books == null || string.IsNullOrEmpty(title)) return null;

            foreach (var book in books)
            {
                if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    return book;
                }
            }
            return null;
        }

        // Binary Search by Title (assumes sorted by Title)
        public static Book BinarySearchByTitle(Book[] books, string title)
        {
            if (books == null || string.IsNullOrEmpty(title)) return null;

            int left = 0;
            int right = books.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = string.Compare(books[mid].Title, title, StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                {
                    return books[mid];
                }
                else if (comparison < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return null;
        }
    }
}
