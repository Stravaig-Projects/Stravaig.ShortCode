using System;
using System.Text;

namespace Stravaig.ShortCode
{
    public class Encoder : IEncoder
    {
        private readonly string _characterSpace;
        public Encoder(string characterSpace)
        {
            if (string.IsNullOrWhiteSpace(characterSpace))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(characterSpace));
            if (characterSpace.Length == 1)
                throw new ArgumentException("Value cannot have a single character.", nameof(characterSpace));
            _characterSpace = characterSpace;
        }
        
        public string Convert(ulong fullCode, int? fixedChars = null, int maxChars = int.MaxValue)
        {
            if (fullCode == 0) 
                throw new ArgumentOutOfRangeException(nameof(fullCode), $"Must be greater than zero.");
            
            if (fixedChars.HasValue && fixedChars.Value < maxChars)
                maxChars = fixedChars.Value;
            
            var result = BuildShortCode(fullCode, maxChars);
            PadToFixedLength(fixedChars, result);
            Reverse(result);

            return result.ToString();
        }

        public ulong RangeRequired(int numChars)
        {
            return (ulong)Math.Pow(_characterSpace.Length, numChars);
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

        private StringBuilder BuildShortCode(ulong fullCode, int maxChars)
        {
            ulong divisor = (ulong) _characterSpace.Length;
            StringBuilder result = new StringBuilder();
            while (fullCode != 0)
            {
                ulong remainder = fullCode % divisor;
                result.Append(_characterSpace[(int) remainder]);
                if (result.Length >= maxChars)
                    break;
                fullCode -= remainder;
                fullCode /= divisor;
            }

            return result;
        }

        private void PadToFixedLength(int? fixedChars, StringBuilder result)
        {
            if (fixedChars.HasValue)
            {
                while (result.Length < fixedChars.Value)
                    result.Append(_characterSpace[0]);
            }
        }
        
        private static void Reverse(StringBuilder sb)
        {
            for (int i = 0; i < sb.Length / 2; i++)
            { 
                var temp = sb[sb.Length - i - 1];  
                sb[sb.Length - i - 1] = sb[i];  
                sb[i] = temp;  
            }  
        }
    }
}