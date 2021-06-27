using System;

namespace Stravaig.ShortCode
{
    public static class ShortCode
    {
        private static int _defaultLength;
        private static Encoder _encoder;
        private static SequentialCodeGenerator _sequentialCodeGenerator;
        private static IShortCodeGenerator _randomGenerator;

        static ShortCode()
        {
            Init();
        }

        private static void Init()
        {
            _defaultLength = 7;
            _encoder = new Encoder(NamedCharacterSpaces.LettersAndDigits);
            _sequentialCodeGenerator = new SequentialCodeGenerator();
            _randomGenerator = new CryptographicallyRandomCodeGenerator();
        }
        
        public static string GenerateSequentialShortCode(int? length = null)
        {
            ulong code = _sequentialCodeGenerator.GetNextCode();
            return _encoder.Convert(code, length ?? _defaultLength);
        }

        public static string GenerateRandomShortCode(int? length = null)
        {
            ulong code = _randomGenerator.GetNextCode();
            return _encoder.Convert(code, length ?? _defaultLength);
        }

        public static void SetSequentialSeed(ulong seed)
        {
            _sequentialCodeGenerator = new SequentialCodeGenerator(seed);
        }

        public static void SetCharacterSpace(string characterSpace)
        {
            _encoder = new Encoder(characterSpace);
        }

        public static void SetDefaultLength(int length)
        {
            int maxLength = _encoder.MaxLength();
            if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length), $"Must be between 1 and {maxLength}");
            if (length > maxLength) throw new ArgumentOutOfRangeException(nameof(length), $"Must be between 1 and {maxLength}");
            _defaultLength = length;
        }

        public static void Use<TGenerator>() where TGenerator : IShortCodeGenerator, new()
        {
            _randomGenerator = new TGenerator();
        }
    }
}