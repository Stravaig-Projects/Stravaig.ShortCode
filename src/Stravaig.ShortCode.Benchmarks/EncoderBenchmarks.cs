using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace Stravaig.ShortCode.Benchmarks
{
    [Config(typeof(Config))]
    public class EncoderBenchmarks
    {
        public class Config : ManualConfig
        {
            public Config()
            {
                AddColumn(new CharacterSpaceColumn());
                AddColumn(new EncoderColumn());
            }
        }
        
        private ulong[] _codes = new ulong[1];

        [Params(3, 5, 7, 9)]
        public int FixedLength { get; set; }

        [ParamsSource(nameof(DefaultEncoders))]
        public IEncoder Encoder { get; set; }
        
        [Params(12335633962698440504, 905021721, 16109257, 54321, 5)]
        public ulong Code { get; set; }

        public static IEnumerable<IEncoder> DefaultEncoders() => new[]
        {
            new Encoder(NamedCharacterSpaces.Digits),
            new Encoder(NamedCharacterSpaces.ReducedAmbiguity),
            new Encoder(NamedCharacterSpaces.LettersAndDigits),
        };
        
        public EncoderBenchmarks()
        {
            var generator = new RandomCodeGenerator(0);
            for (int i = 0; i < _codes.Length; i++)
                _codes[i] = generator.GetNextCode();
        }

        [Benchmark]
        public void Convert() => Encoder.Convert(Code, FixedLength);
    }
}