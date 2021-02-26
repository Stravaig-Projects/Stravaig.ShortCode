using NUnit.Framework;

namespace Stravaig.ShortCode.Tests
{
    [TestFixture]
    public class PatternedEncoderTests
    {
        [TestCase(1UL, ExpectedResult = "AA-00-ab")]
        [TestCase(27UL, ExpectedResult = "AA-00-bb")]
        [TestCase(675UL, ExpectedResult = "AA-00-zz")]
        [TestCase(676UL, ExpectedResult = "AA-01-aa")]
        [TestCase(677UL, ExpectedResult = "AA-01-ab")]
        [TestCase(6760UL, ExpectedResult = "AA-10-aa")]
        [TestCase(6761UL, ExpectedResult = "AA-10-ab")]
        [TestCase(67600UL, ExpectedResult = "AB-00-aa")]
        [TestCase(1757600UL, ExpectedResult = "BA-00-aa")]
        [TestCase(45697599UL, ExpectedResult = "ZZ-99-zz")]
        [TestCase(45697600UL, ExpectedResult = "AA-00-aa")]
        public string ConvertPattern(ulong code)
        {
            PatternedEncoder encoder = new PatternedEncoder(new[]
            {
                new PatternPart(NamedCharacterSpaces.UpperLatinLetters, 2),
                new PatternPart("-"),
                new PatternPart(NamedCharacterSpaces.Digits, 2),
                new PatternPart("-"),
                new PatternPart(NamedCharacterSpaces.LowerLatinLetters, 2),
            });

            return encoder.Convert(code);
        }
    }
}