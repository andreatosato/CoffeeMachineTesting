using BenchmarkDotNet.Attributes;
using CoffeeMachine.Logic.Domain;
using System.Collections.Generic;

namespace CoffeeMachine.Test.Performance
{
    [MemoryDiagnoser]
    [DryJob]
    //[JsonExporterAttribute.Brief]
    //[JsonExporterAttribute.Full]
    //[JsonExporterAttribute.BriefCompressed]
    //[JsonExporterAttribute.FullCompressed]
    [AllStatisticsColumn]
    //[JsonExporter("-order", indentJson: true, excludeMeasurements: false)]
    public class OrderBenchmark
    {
        [GlobalSetup]
        public void Setup()
        {
            //Nothing to do
        }

        public IEnumerable<object[]> Drinks()
        {
            yield return new object[] { new Coffee(), 1m };
            yield return new object[] { new Coffee(), 2m };
            yield return new object[] { new The(), 0.8m };
            yield return new object[] { new The(), 2m };
            yield return new object[] { new Cappuccino(), 1m };
            yield return new object[] { new Cappuccino(), 2m };
        }

        [ArgumentsSource(nameof(Drinks))]
        [Benchmark]
        public void CreateOrder(Drink d, decimal price)
        {
            var order = new Order(d, price);
        }
    }
}
