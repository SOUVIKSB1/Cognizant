namespace SortingCustomerOrders
{
    public static class SortingAlgorithms
    {
        // Bubble Sort
        public static void BubbleSort(Order[] orders)
        {
            if (orders == null || orders.Length <= 1) return;
            int n = orders.Length;

            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (orders[j].TotalPrice > orders[j + 1].TotalPrice)
                    {
                        // Swap orders[j] and orders[j+1]
                        Order temp = orders[j];
                        orders[j] = orders[j + 1];
                        orders[j + 1] = temp;
                        swapped = true;
                    }
                }
                // If no two elements were swapped by inner loop, then break
                if (!swapped) break;
            }
        }

        // Quick Sort (Wrapper)
        public static void QuickSort(Order[] orders)
        {
            if (orders == null || orders.Length <= 1) return;
            QuickSortHelper(orders, 0, orders.Length - 1);
        }

        private static void QuickSortHelper(Order[] orders, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(orders, low, high);

                // Recursively sort elements before and after partition
                QuickSortHelper(orders, low, pi - 1);
                QuickSortHelper(orders, pi + 1, high);
            }
        }

        private static int Partition(Order[] orders, int low, int high)
        {
            double pivot = orders[high].TotalPrice;
            int i = (low - 1); // Index of smaller element

            for (int j = low; j < high; j++)
            {
                // If current element is smaller than or equal to pivot
                if (orders[j].TotalPrice <= pivot)
                {
                    i++;
                    // Swap orders[i] and orders[j]
                    Order temp = orders[i];
                    orders[i] = orders[j];
                    orders[j] = temp;
                }
            }

            // Swap orders[i+1] and orders[high] (or pivot)
            Order temp2 = orders[i + 1];
            orders[i + 1] = orders[high];
            orders[high] = temp2;

            return i + 1;
        }
    }
}
