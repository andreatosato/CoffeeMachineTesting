using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using System;
using Xunit;

namespace CoffeeMachine.Test.Performance
{
    public class PerformanceRunner
    {
        [Fact]
        public void OrderBenchmark_Ctor_Runner()
        {
            var summary = BenchmarkRunner.Run<OrderBenchmark>();
        }
    }
}