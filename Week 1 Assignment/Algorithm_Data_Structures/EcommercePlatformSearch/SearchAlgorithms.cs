using System;

namespace EcommercePlatformSearch
{
    public static class SearchAlgorithms
    {
        // Linear Search
        // Returns the index of the product if found; otherwise, -1.
        public static int LinearSearch(Product[] products, string targetName)
        {
            if (products == null || string.IsNullOrEmpty(targetName)) return -1;

            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].ProductName.Equals(targetName, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            return -1;
        }

        // Binary Search
        // Assumes products array is sorted by ProductName (ascending).
        // Returns the index of the product if found; otherwise, -1.
        public static int BinarySearch(Product[] products, string targetName)
        {
            if (products == null || string.IsNullOrEmpty(targetName)) return -1;

            int left = 0;
            int right = products.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = string.Compare(products[mid].ProductName, targetName, StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                {
                    return mid;
                }
                else if (comparison < 0)
                {
                    left = mid + 1; // Target is in the right half
                }
                else
                {
                    right = mid - 1; // Target is in the left half
                }
            }
            return -1;
        }
    }
}
