using System;
using BenchmarkDotNet.Attributes;

namespace Stravaig.ShortCode.Benchmarks
{
    [MarkdownExporterAttribute.GitHub]
    public class CodeGeneratorBenchmarks
    {
        private RandomCodeGenerator _random = new RandomCodeGenerator();
        private GuidCodeGenerator _guid = new GuidCodeGenerator();
        private SequentialCodeGenerator _sequential = new SequentialCodeGenerator(0);
        private CryptographicallyRandomCodeGenerator _cryptoRandom = new CryptographicallyRandomCodeGenerator();

        public CodeGeneratorBenchmarks()
        {
            
        }

        [Benchmark]
        public void RandomGenerator() => _random.GetNextCode();

        [Benchmark]
        public void GuidGenerator() => _guid.GetNextCode();

        [Benchmark]
        public void SequentialGenerator() => _sequential.GetNextCode();

        [Benchmark]
        public void CryptographicallyRandomGenerator() => _cryptoRandom.GetNextCode();
    }
}
