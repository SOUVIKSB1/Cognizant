using System;

namespace DependencyInjectionExample
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        // Constructor Injection
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void DisplayCustomerName(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                Console.WriteLine("CustomerService: Invalid Customer ID.");
                return;
            }

            string name = _customerRepository.FindCustomerById(customerId);

            if (name != null)
            {
                Console.WriteLine($"CustomerService: Customer found. ID: {customerId} | Name: {name}");
            }
            else
            {
                Console.WriteLine($"CustomerService: Customer with ID {customerId} not found.");
            }
        }
    }
}
