using System.Text;
using RabbitMQ.Client;


var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "messages-queue", false, false, false, null);

const string message = "Hola";
var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(string.Empty,  "messages",
                     basicProperties: null,
                     body: body);
Console.WriteLine($" [x] Sent {message}");

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();