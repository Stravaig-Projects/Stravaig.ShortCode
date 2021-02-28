using System;
using System.Collections.Generic;
using Stravaig.ShortCode.Internal;

namespace Stravaig.ShortCode
{
    public class ShortCodeOptions
    {
        private const int AbsoluteMinLength = 1;
        private const int AbsoluteMaxLength = 64;

        private int _maxLength = AbsoluteMaxLength;
        private int? _fixedLength;
        private string _characterSpace = NamedCharacterSpaces.ReducedAmbiguity;

        public string CharacterSpace
        {
            get => _characterSpace;
            set
            {
                value.ValidateCharacterSpace();
                _characterSpace = value;
            }
        }



        public int MaxLength
        {
            get => _maxLength;
            set
            {
                if (value < AbsoluteMinLength || value > AbsoluteMaxLength)
                    throw new ArgumentOutOfRangeException(
                        nameof(MaxLength),
                        $"The value must be between {AbsoluteMinLength} and {AbsoluteMaxLength}.");
                _maxLength = value;
            }
        }

        public int? FixedLength
        {
            get => _fixedLength;
            set
            {
                if (value.HasValue && (value.Value < AbsoluteMinLength || value.Value > AbsoluteMaxLength))
                    throw new ArgumentOutOfRangeException(
                        nameof(FixedLength),
                        $"The value, if present, must be between {AbsoluteMinLength} and {AbsoluteMaxLength}");
                _fixedLength = value;
            }
        }

        public Dictionary<string, object> Generator { get; set; } = new Dictionary<string, object>();

        public PatternOptions[] Pattern { get; set; } = Array.Empty<PatternOptions>();
    }
}