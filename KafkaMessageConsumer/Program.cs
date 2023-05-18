using Confluent.Kafka;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

var config = new ConsumerConfig
{
    GroupId = "MensajesPruebaGroup",
    BootstrapServers = "localhost:9092",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using var consumer = new ConsumerBuilder<Null, string>(config).Build();
consumer.Subscribe("Cliente");
CancellationTokenSource token = new();

try
{

    while (true)
    {
        var response = consumer.Consume(token.Token);
        Console.WriteLine("La respuesta es: {0} ", response.Message.Value);
       // var mesanjeConsumer = JsonConvert.DeserializeObject<MensajeConsumer>
        //    (response.Message.Value);
      //  Console.WriteLine($"Mensaje: {mesanjeConsumer.mensaje}");
    }
}
catch (Exception e)
{
    Console.WriteLine(e.ToString());
    throw new Exception();
}
 public record MensajeConsumer (string mensaje, int algo);