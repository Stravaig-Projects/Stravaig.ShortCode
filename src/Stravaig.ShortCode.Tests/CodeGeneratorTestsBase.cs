using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Shouldly;

namespace Stravaig.ShortCode.Tests
{
    public class CodeGeneratorTestsBase
    {
        private const int RunSize = 1024 * 1024 * 4;
        
        private void GenerateLots(IShortCodeGenerator gen, ulong[] result)
        {
            int count = result.Length;
            for (int i = 0; i < count; i++)
            {
                result[i] = gen.GetNextCode();
            }
        }
        
        protected void MultiThreadStressTest(IShortCodeGenerator gen)
        {
            var threadCount = Environment.ProcessorCount * 2;
            var tasks = new List<Task<ulong[]>>(threadCount);
            for (int i = 0; i < threadCount; i++)
            {
                var result = new ulong[RunSize];
                int index = i;
                tasks.Add(new Task<ulong[]>(() =>
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    GenerateLots(gen, result);
                    sw.Stop();
                    ResultReadOut(result.Length, sw, index);
                    return result;
                }));
            }
            
            Stopwatch sw = new Stopwatch();
            sw.Start();
            tasks.ForEach(t => t.Start());
            Task.WaitAll(tasks.Cast<Task>().ToArray(), 1000 * threadCount);
            sw.Stop();
            var totalCount = tasks.Select(t => t.Result.Length).Sum();
            ResultReadOut(totalCount, sw);

            var allResults = tasks.SelectMany(t => t.Result);
            CheckAccuracy(allResults);
        }
        
        protected void SingleThreadStressTest(IShortCodeGenerator gen)
        {
            var result = new ulong[RunSize];
            Stopwatch sw = new Stopwatch();
            sw.Start();
            GenerateLots(gen, result);
            sw.Stop();
            ResultReadOut(result.Length, sw);

            CheckAccuracy(result);
        }

        private static void CheckAccuracy(IEnumerable<ulong> result)
        {
            var totalCount = result.Count();
            var distinctCount = result.Distinct().Count();
            var errorRatePercent = 1.0 - (distinctCount / (double) totalCount);
            var errorRate = 1 / errorRatePercent;
            Console.WriteLine($"{distinctCount} of {totalCount} unique results. ({errorRatePercent:P2} error rate; or 1 in every {errorRate:F0})");
            distinctCount.ShouldBe(totalCount);
        }

        private void ResultReadOut(int totalCount, Stopwatch sw, int? index = null, [CallerMemberName]string caller = null)
        {
            var elapsedMs = (double)sw.ElapsedMilliseconds;
            var perCallTime = elapsedMs / totalCount;
            var perCallTimeUnit = "ms";
            if (perCallTime < 0.001)
            {
                perCallTime *= 1000.0;
                perCallTimeUnit = "µs";
            }

            if (perCallTime < 0.001)
            {
                perCallTime *= 1000.0;
                perCallTimeUnit = "ns";
            }

            if (perCallTime < 0.001)
            {
                perCallTime *= 1000.0;
                perCallTimeUnit = "ps";
            }

            string indexRep = string.Empty;
            if (index.HasValue)
                indexRep = $"[{index.Value}]";
            Console.WriteLine(
                $"{GetType().Name}.{caller}{indexRep}: {totalCount} iterations took {elapsedMs}ms, or {perCallTime:F3}{perCallTimeUnit} per call.");
        }
    }
}