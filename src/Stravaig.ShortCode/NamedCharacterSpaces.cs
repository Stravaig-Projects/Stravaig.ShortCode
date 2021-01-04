using System.Collections.Generic;

namespace Stravaig.ShortCode
{
    public class NamedCharacterSpaces
    {
        public const string Digits = "0123456789";
        public const string Hex = "0123456789ABCDEF";
        public const string UpperLatinLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string LowerLatinLetters = "abcdefghijklmnopqrstuvwxyz";
        public const string LatinLetters = LowerLatinLetters + UpperLatinLetters;
        public const string LettersAndDigits = LatinLetters + Digits;
        public const string ReducedAmbiguity = "ABCDEFGHJKLMNPRTUVWXY2346789";

        public static readonly IReadOnlyDictionary<string, string> SpaceToName = new Dictionary<string, string>
        {
            {Digits, nameof(Digits)},
            {Hex, nameof(Hex)},
            {UpperLatinLetters, nameof(UpperLatinLetters)},
            {LowerLatinLetters, nameof(LowerLatinLetters)},
            {LatinLetters, nameof(LatinLetters)},
            {LettersAndDigits, nameof(LettersAndDigits)},
            {ReducedAmbiguity, nameof(ReducedAmbiguity)},
        };
    }
}