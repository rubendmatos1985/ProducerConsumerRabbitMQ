using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            using var connection = factory.CreateConnection();
            
            using var channel = connection.CreateModel();
            
            channel.QueueDeclare(queue: "BasicTest", durable: false, exclusive: false, autoDelete: false, arguments: null);
            
            string message = "Getting started with .Net Core RabbitMQ";
            
            var body = Encoding.UTF8.GetBytes(message);
            
            channel.BasicPublish(exchange: "", routingKey: "BasicTest", body: body);
            
            Console.WriteLine($"Sent message {message}");
            
            Console.ReadLine();
        }
    }
}
