using BenchmarkDotNet.Attributes;
using Stravaig.ShortCode.Benchmarks.Variants;

namespace Stravaig.ShortCode.Benchmarks
{
    public class EncoderVariantBenchmarks
    {
        private ulong[] _codes = new ulong[1024];
        private int _index = 0;
        private Encoder _baselineEncoder = new Encoder(NamedCharacterSpaces.ReducedAmbiguity);
        private Encoder1 _encoder1 = new Encoder1(NamedCharacterSpaces.ReducedAmbiguity);
        private Encoder2 _encoder2 = new Encoder2(NamedCharacterSpaces.ReducedAmbiguity);

        public EncoderVariantBenchmarks()
        {
            var gen = new RandomCodeGenerator(0);
            for (int i = 0; i < _codes.Length; i++)
                _codes[i] = gen.GetNextCode();
        }
        
        private ulong Code
        {
            get
            {
                _index++;
                if (_index >= _codes.Length)
                    _index = 0;

                return _codes[_index];
            }
        }
        
        // This is the current version in the main project
        [Benchmark(Baseline = true, Description = "The version that is currently in the main project.")]
        public void Baseline() => _baselineEncoder.Convert(Code, (_index % 8) + 3);

        // This is the version in the main project as of 03/Jan/2021
        [Benchmark(Description = "03/Jan/2021 Variant")]
        public void Variant_1 () => _encoder1.Convert(Code, (_index % 8) + 3);

        [Benchmark(Description = "04/Jan/2021 Variant")]
        public void Variant_2 () => _encoder2.Convert(Code, (_index % 8) + 3);

        [Benchmark(Description = "Repeat the baseline.")]
        public void Baseline2() => _baselineEncoder.Convert(Code, (_index % 8) + 3);

        
    }
}