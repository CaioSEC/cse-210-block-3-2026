using System;

namespace ProductOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            // ------------------------------------------------------------
            // Order 1: Domestic Customer (USA)
            // ------------------------------------------------------------
            Address address1 = new Address("123 Somewhere Way", "Rexburg", "ID", "USA");
            Customer customer1 = new Customer("Ricky Hirschi", address1);
            Order order1 = new Order(customer1);

            order1.AddProduct(new Product("Keyboard", "KB-900", 85.50, 1));
            order1.AddProduct(new Product("Ergonomic Mouse", "MS-400", 45.00, 2));

            // ------------------------------------------------------------
            // Order 2: International Customer (Brazil)
            // ------------------------------------------------------------
            Address address2 = new Address("Av. Santos Dumont, 700", "Fortaleza", "CE", "Brazil");
            Customer customer2 = new Customer("Caio Nogueira", address2);
            Order order2 = new Order(customer2);

            order2.AddProduct(new Product("Monitor 27\"", "MON-34X", 350.00, 1));
            order2.AddProduct(new Product("HDMI 2.1 Cable", "CBL-HDMI21", 15.25, 3));
            order2.AddProduct(new Product("Desk Pad", "MAT-XL", 25.00, 1));

            // ------------------------------------------------------------
            // Display Results
            // ------------------------------------------------------------
            Console.WriteLine("==================================================");
            Console.WriteLine("             ORDER PROCESSING SYSTEM              ");
            Console.WriteLine("==================================================\n");

            // Display Order 1
            Console.WriteLine(">>> PROCESSING ORDER #1 <<<");
            Console.Write(order1.GetShippingLabel());
            Console.Write(order1.GetPackingLabel());
            Console.WriteLine($"Total Invoice Price: ${order1.CalculateTotalCost():F2}");
            Console.WriteLine("\n--------------------------------------------------\n");

            // Display Order 2
            Console.WriteLine(">>> PROCESSING ORDER #2 <<<");
            Console.Write(order2.GetShippingLabel());
            Console.Write(order2.GetPackingLabel());
            Console.WriteLine($"Total Invoice Price: ${order2.CalculateTotalCost():F2}");
            Console.WriteLine("\n--------------------------------------------------\n");
        }
    }
}