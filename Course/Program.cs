using System;
using Course.Entities.Enum;
using Course.Entities;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data: ");
            
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDate);

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            

            Console.Write("How many items to this order? ");
            int numberItems = int.Parse(Console.ReadLine());


            Order order = new Order(status, client);


            for (int i = 1; i <= numberItems; i++)
            {
                Console.WriteLine("Enter #"+ i + " item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine());
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(productName, price);
                OrderItem item = new OrderItem(quantity, price, product);

                order.AddItem(item);

            }

            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine("Order moment: " + order.Moment);
            Console.WriteLine("Order status: " + order.Status);
            Console.WriteLine("Client: " + client.Name + " (" + client.BirthDate.ToString("dd/MM/yyyy") + ") - " + client.Email);
            Console.WriteLine("Order Items: ");
            foreach (OrderItem item_ in order.Items)
            {
                Console.WriteLine( item_ );
            }

            Console.WriteLine("Total price: " + order.Total());

        }
    }
}
