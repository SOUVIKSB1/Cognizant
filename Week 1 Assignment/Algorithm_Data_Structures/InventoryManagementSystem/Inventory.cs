using System;
using System.Collections.Generic;

namespace InventoryManagementSystem
{
    public class Inventory
    {
        private readonly Dictionary<string, Product> _products;

        public Inventory()
        {
            _products = new Dictionary<string, Product>();
        }

        // Add Product
        public bool AddProduct(Product product)
        {
            if (product == null) return false;
            if (_products.ContainsKey(product.ProductId))
            {
                Console.WriteLine($"Error: Product with ID {product.ProductId} already exists.");
                return false;
            }
            _products.Add(product.ProductId, product);
            return true;
        }

        // Update Product
        public bool UpdateProduct(string productId, Product updatedProduct)
        {
            if (updatedProduct == null) return false;
            if (!_products.ContainsKey(productId))
            {
                Console.WriteLine($"Error: Product with ID {productId} not found.");
                return false;
            }
            _products[productId] = updatedProduct;
            return true;
        }

        // Delete Product
        public bool DeleteProduct(string productId)
        {
            if (!_products.ContainsKey(productId))
            {
                Console.WriteLine($"Error: Product with ID {productId} not found.");
                return false;
            }
            _products.Remove(productId);
            return true;
        }

        // Get Product
        public Product GetProduct(string productId)
        {
            if (_products.TryGetValue(productId, out var product))
            {
                return product;
            }
            return null;
        }

        // Print All Products
        public void DisplayAllProducts()
        {
            if (_products.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }
            Console.WriteLine("\n--- Current Inventory ---");
            foreach (var product in _products.Values)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("-------------------------\n");
        }
    }
}
