using Stravaig.ShortCode.Internal;

namespace Stravaig.ShortCode
{
    public class PatternOptions
    {
        private string _characterSpace;
        public PatternType Type { get; set; }

        public string CharacterSpace
        {
            get => _characterSpace;
            set
            {
                value.ValidateCharacterSpace();
                _characterSpace = value;
            }
        }
            
        public int Length { get; set; }
            
        public string FixedString { get; set; }

        public PatternOptions()
        {
        }

        public PatternOptions(string fixedString)
        {
            Type = PatternType.Fixed;
            FixedString = fixedString;
            Length = fixedString.Length;
        }

        public PatternOptions(string characterSpace, int length)
        {
            Type = PatternType.EncodeIntoCharacterSpace;
            CharacterSpace = characterSpace;
            Length = length;
        }
    }
}