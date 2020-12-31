namespace Stravaig.ShortCode
{
    public class ShortCodeOptions
    {
        public string CharacterSpace { get; set; } = Encoder.ReducedAmbiguity;
        public int MaxLength { get; set; } = int.MaxValue;
        public int? FixedLength { get; set; }
    }
}