using System;
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace PocNetRabbitMQ
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("1 - Producer");
            Console.WriteLine("2 - Consumer");
            Console.Write("Escolha: ");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                await RunProducer();
            }
            else if (choice == "2")
            {
                await RunConsumer();
            }          
        }
        static async Task RunProducer()
        {
            while (true)
            {
                var product = new Product();
                product.Id = 1;

                Console.Write("Digite o nome do produto (ou sair): ");
                string input = Console.ReadLine();
                if (input?.ToLower() == "sair") break;
                product.Name = input;

                Console.Write("Digite o valor do produto (ou sair): ");
                input = Console.ReadLine();
                if (input?.ToLower() == "sair") break;
                product.Price = Double.Parse(input);

                var producer = new Producer();
                await producer.Send(JsonSerializer.Serialize(product));
            }
        }

        static async Task RunConsumer()
        {
            var producer = new Consumer();
            await producer.Receive();
        }
    }
}
