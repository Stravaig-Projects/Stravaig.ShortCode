namespace Stravaig.ShortCode.DependencyInjection
{
    internal static class PatternOptionsExtensions
    {
        public static PatternPart ToPatternPart(this ShortCodeOptions.PatternOptions options)
        {
            if (options.Type == PatternType.Fixed)
                return new PatternPart(options.FixedString);
            return new PatternPart(options.CharacterSpace, options.Length);
        }
    }
}