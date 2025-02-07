using Confluent.Kafka;
using System;

namespace KafkaHelloWorld {
  class Program {
    public static void Main(string[] args) {
      var config = new ProducerConfig {
        BootstrapServers = "localhost:9092"
      };

      using (var producer = new ProducerBuilder<Null, string>(config).Build()) {
        try {
          var result = producer.ProduceAsync("test-topic", new Message<Null, string> { Value = "Hello Kafka from C#" }).Result;
          Console.WriteLine($"Message sent to {result.TopicPartitionOffset}");
        } catch (ProduceException<Null, string> e) {
          Console.WriteLine($"Error sending message: {e.Error.Reason}");
        }
      }
    }
  }
}
