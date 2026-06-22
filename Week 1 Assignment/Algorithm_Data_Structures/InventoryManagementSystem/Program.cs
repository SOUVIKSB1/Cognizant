using System;

namespace InventoryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Inventory Management System Test");
            Console.WriteLine("========================================");

            Inventory inventory = new Inventory();

            // 1. Add Products
            Console.WriteLine("Adding products...");
            Product p1 = new Product("P001", "Laptop", 10, 999.99);
            Product p2 = new Product("P002", "Smartphone", 25, 499.99);
            Product p3 = new Product("P003", "Headphones", 50, 79.99);

            inventory.AddProduct(p1);
            inventory.AddProduct(p2);
            inventory.AddProduct(p3);

            inventory.DisplayAllProducts();

            // 2. Update Product
            Console.WriteLine("Updating Smartphone quantity to 30 and price to 449.99...");
            Product updatedP2 = new Product("P002", "Smartphone", 30, 449.99);
            inventory.UpdateProduct("P002", updatedP2);

            inventory.DisplayAllProducts();

            // 3. Search Product
            Console.WriteLine("Searching for product P001...");
            Product found = inventory.GetProduct("P001");
            if (found != null)
            {
                Console.WriteLine($"Found: {found}");
            }
            else
            {
                Console.WriteLine("Product P001 not found.");
            }

            // 4. Delete Product
            Console.WriteLine("\nDeleting Headphones (P003)...");
            inventory.DeleteProduct("P003");

            inventory.DisplayAllProducts();

            Console.WriteLine("Inventory management test completed.");
        }
    }
}
