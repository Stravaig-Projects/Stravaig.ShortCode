using System;
using BenchmarkDotNet.Running;

namespace Stravaig.ShortCode.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
