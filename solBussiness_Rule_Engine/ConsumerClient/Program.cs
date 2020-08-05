using Implementations.Commission;
using Implementations.Membership;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Services;
using System;

namespace ConsumerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton<ICommission, AgentCommission>()
            .AddSingleton<IMembership, CustomerMembership>()
            .BuildServiceProvider();

            ICommission commission = serviceProvider.GetService<ICommission>();
            IMembership membership = serviceProvider.GetService<IMembership>();

            PaymentService paymentService = new PaymentService(commission, membership);
            PaymentResult result;
            Console.WriteLine("Books");
            Product product = new Product() { Agent = 1, Amount = 1000.00, Category = 1, ProductId = 1, ProductType = "Books", ProductName = "Book 1" };

            result = paymentService.MakePayment(product);
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Toys");
            Product product2 = new Product() { Agent = 1, Amount = 1000.00, Category = 1, ProductId = 1, ProductType = "", ProductName = "Toy 1" };

            paymentService.MakePayment(product2);
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Video");
            Product product3 = new Product() { Agent = 1, Amount = 2000.00, Category = 2, ProductId = 1, ProductType = "", ProductName = "Learning To Ski" };

            paymentService.MakePayment(product3);
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("New Membership");
            Product product4 = new Product() { Agent = 1, Amount = 2000.00, Category = 3, ProductId = 1, ProductType = "New", ProductName = "Video" };

            paymentService.MakePayment(product4);
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Upgrade Membership");
            Product product5 = new Product() { Agent = 1, Amount = 2000.00, Category = 3, ProductId = 1, ProductType = "Upgrade", ProductName = "Video" };

            paymentService.MakePayment(product5);
            Console.ReadLine();
            //Console.WriteLine("Hello World!");
        }
    }
}
