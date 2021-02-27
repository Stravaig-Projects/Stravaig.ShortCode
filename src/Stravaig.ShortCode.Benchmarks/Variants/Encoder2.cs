using System;
namespace Stravaig.ShortCode.Benchmarks.Variants
{
    public class Encoder2 : IEncoder
    {
        private readonly string _characterSpace;
        public Encoder2(string characterSpace)
        {
            if (string.IsNullOrWhiteSpace(characterSpace))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(characterSpace));
            if (characterSpace.Length == 1)
                throw new ArgumentException("Value cannot have a single character.", nameof(characterSpace));
            _characterSpace = characterSpace;
        }
        
        public string Convert(ulong fullCode, int? fixedChars = null, int maxChars = 64)
        {
            if (fullCode == 0) 
                throw new ArgumentOutOfRangeException(nameof(fullCode), $"Must be greater than zero.");
            
            if (fixedChars.HasValue && fixedChars.Value < maxChars)
                maxChars = fixedChars.Value;
            
            var (resultChars, index) = BuildShortCode(fullCode, maxChars);
            index = PadToFixedLength(fixedChars, resultChars, index);
            Reverse(resultChars, index);

            return new String(resultChars, 0, index);
        }

        public int MaxLength()
        {
            return (int)(Math.Log(ulong.MaxValue) / Math.Log(_characterSpace.Length));
        }

        public string CharacterSpace => _characterSpace;

        public string NamedCharacterSpace =>
            NamedCharacterSpaces.SpaceToName.TryGetValue(_characterSpace, out string result)
                ? result
                : null;

        public override string ToString()
        {
            if (NamedCharacterSpaces.SpaceToName.TryGetValue(_characterSpace, out string name))
                return $"{GetType().Name}({name})";
            return $"{GetType().Name}(\"{_characterSpace}\")";
        }

        private (char[], int) BuildShortCode(ulong fullCode, int maxChars)
        {
            ulong divisor = (ulong) _characterSpace.Length;
            char[] resultChars = new char[maxChars];
            int index = 0;
            while (fullCode != 0)
            {
                ulong remainder = fullCode % divisor;
                resultChars[index] = _characterSpace[(int) remainder];
                index++;
                if (index >= maxChars)
                    break;
                fullCode = (fullCode - remainder) / divisor;
            }

            return (resultChars, index);
        }

        private int PadToFixedLength(int? fixedChars, char[] resultChars, int index)
        {
            if (fixedChars.HasValue)
            {
                while (index < fixedChars.Value)
                    resultChars[index++] = _characterSpace[0];
            }

            return index;
        }
        
        private static void Reverse(char[] resultChars, int length)
        {
            var halfWay = length / 2;
            for (int i = 0; i < halfWay; i++)
            {
                var endIndex = length - i - 1;
                var temp = resultChars[endIndex];  
                resultChars[endIndex] = resultChars[i];  
                resultChars[i] = temp;
            }
        }
    }
}
