using System;
using System.Text;

namespace Stravaig.ShortCode
{
    public class Encoder : IEncoder
    {
        public const string Digits = "0123456789";
        public const string Hex = "0123456789ABCDEF";
        public const string UpperLatinLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string LowerLatinLetters = "abcdefghijklmnopqrstuvwxyz";
        public const string LatinLetters = LowerLatinLetters + UpperLatinLetters;
        public const string LettersAndDigits = LatinLetters + Digits;
        public const string ReducedAmbiguity = "ABCDEFGHJKLMNPRTUVWXY2346789";

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