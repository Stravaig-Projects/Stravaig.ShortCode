using System;
using System.Collections.Generic;
using System.Linq;

namespace Stravaig.ShortCode
{
    public class PatternedEncoder : IEncoder
    {
        private readonly PatternPart[] _parts;
        private readonly int _length;

        public PatternedEncoder(IEnumerable<PatternPart> parts)
        {
            _parts = parts.ToArray();
            _length = _parts.Sum(p => p.Length);
        }

        public string Convert(ulong fullCode, int? fixedChars = null, int maxChars = Int32.MaxValue)
        {
            if (fullCode == 0) 
                throw new ArgumentOutOfRangeException(nameof(fullCode), $"Must be greater than zero.");

            char[] result = new char[_length];
            ulong code = fullCode;
            int position = _length;
            for (int i = _parts.Length - 1; i >= 0; i--)
            {
                var part = _parts[i];
                position -= part.Length;
                code = BuildShortCode(code, part, result, position);
            }

            return new string(result);
        }
        
        private ulong BuildShortCode(ulong fullCode, PatternPart part, char[] code, int position)
        {
            if (part.Type == PatternType.Fixed)
            {
                for (int i = 0; i < part.Length; i++)
                    code[position + i] = part.Pattern[i];
                return fullCode;
            }

            ulong divisor = (ulong) part.Pattern.Length;
            for (int i = (position + part.Length - 1); i >= position; i--)
            {
                ulong remainder = fullCode % divisor;
                code[i] = part.Pattern[(int) remainder];
                fullCode = (fullCode - remainder) / divisor;
            }

            return fullCode;
        }

        public int MaxLength()
        {
            throw new NotImplementedException();
        }

        public string NamedCharacterSpace =>
            throw new InvalidOperationException($"{nameof(NamedCharacterSpace)} is not applicable to this encoder.");

        public string CharacterSpace =>
            throw new InvalidOperationException($"{nameof(CharacterSpace)} is not applicable to this encoding.");
    }
}