using System;
using System.Text;
using RabbitMQ.Client;

namespace PocNetRabbitMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var producer = new RabbitMQProducer();
            var a = producer.Producer("Olá Diego").Result;

        }       
    }
}
