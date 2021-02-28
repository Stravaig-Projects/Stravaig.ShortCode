namespace Stravaig.ShortCode
{
    public class PatternPart
    {
        public string Pattern { get; set; }
        public PatternType Type { get; set; }
        public int Length { get; set; }

        public PatternPart(string fixedChars)
        {
            Pattern = fixedChars;
            Type = PatternType.Fixed;
            Length = fixedChars.Length;
        }

        public PatternPart(string characterSpace, int length)
        {
            Pattern = characterSpace;
            Type = PatternType.EncodeIntoCharacterSpace;
            Length = length;
        }
    }
}