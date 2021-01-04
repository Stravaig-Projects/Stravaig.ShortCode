using System.Collections.Generic;

namespace Stravaig.ShortCode
{
    public class ShortCodeOptions
    {
        public string CharacterSpace { get; set; } = Stravaig.ShortCode.NamedCharacterSpaces.ReducedAmbiguity;
        public int MaxLength { get; set; } = int.MaxValue;
        public int? FixedLength { get; set; }

        public Dictionary<string, object> Generator { get; set; } = new Dictionary<string, object>();
    }
}