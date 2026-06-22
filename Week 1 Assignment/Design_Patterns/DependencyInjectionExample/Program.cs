using System;

namespace DependencyInjectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Dependency Injection Example");
            Console.WriteLine("========================================");

            // 1. Create the repository dependency
            ICustomerRepository repository = new CustomerRepositoryImpl();

            // 2. Inject repository into service using Constructor Injection
            CustomerService service = new CustomerService(repository);

            // 3. Query customer names using service
            Console.WriteLine("\nQuerying customer C001...");
            service.DisplayCustomerName("C001");

            Console.WriteLine("\nQuerying customer C003...");
            service.DisplayCustomerName("C003");

            Console.WriteLine("\nQuerying non-existent customer C005...");
            service.DisplayCustomerName("C005");

            Console.WriteLine("\nDependency Injection demonstration completed.");
        }
    }
}
