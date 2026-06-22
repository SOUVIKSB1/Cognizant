using System;
using System.Collections.Generic;

namespace DependencyInjectionExample
{
    public class CustomerRepositoryImpl : ICustomerRepository
    {
        private readonly Dictionary<string, string> _customerDatabase;

        public CustomerRepositoryImpl()
        {
            // Seed simulated customer database
            _customerDatabase = new Dictionary<string, string>
            {
                { "C001", "Souvik Sen" },
                { "C002", "Jane Smith" },
                { "C003", "John Doe" }
            };
        }

        public string FindCustomerById(string id)
        {
            if (_customerDatabase.TryGetValue(id, out var customerName))
            {
                return customerName;
            }
            return null;
        }
    }
}
