using System;
using BenchmarkDotNet.Running;

namespace BenchmarkMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<BenchmarkMapperDemo>();
        }
    }
}
