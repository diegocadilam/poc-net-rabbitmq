using System;
using System.Collections;
using RabbitMQ.Client;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using RabbitMQ.Client.Events;
using System.Text.Json;

namespace PocNetRabbitMQ
{
    public class Consumer
    {
        public async Task<bool> Receive()
        {

            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: "hello", durable: false, exclusive: false, autoDelete: false,
                arguments: null);

            Console.WriteLine(" [*] Waiting for messages.");

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var product = JsonSerializer.Deserialize<Product>(message);
                Console.WriteLine($" [x] Received {product.Name + " " + product.Price.ToString("N2")}");
                return Task.CompletedTask;
            };

            await channel.BasicConsumeAsync("hello", autoAck: true, consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
            return true;    
        }
    }
}
