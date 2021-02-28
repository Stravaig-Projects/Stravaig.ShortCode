using System;
using NUnit.Framework;
using Shouldly;

namespace Stravaig.ShortCode.Tests
{
    [TestFixture]
    public class EncoderTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void Ctor_WithNullOrWhitespace(string value)
        {
            ArgumentException ex = Should.Throw<ArgumentException>(() => new Encoder(value));
            ex.ParamName.ShouldBe("characterSpace");
            ex.Message.ShouldStartWith("Value cannot be null or whitespace.");
        }

        [Test]
        public void Ctor_WithSingleCharacter()
        {
            ArgumentException ex = Should.Throw<ArgumentException>(() => new Encoder("1"));
            ex.ParamName.ShouldBe("characterSpace");
            ex.Message.ShouldStartWith("Value cannot have a single character.");
        }
        
        [TestCase(NamedCharacterSpaces.LettersAndDigits, ExpectedResult = 10)]
        [TestCase(NamedCharacterSpaces.Digits, ExpectedResult = 19)]
        public int MaxLengthTests(string charSpace)
        {
            var characterSpace = new Encoder(charSpace);
            return characterSpace.MaxLength();
        }

        [TestCase((ulong)1, NamedCharacterSpaces.Digits, ExpectedResult = "1")]
        [TestCase((ulong)10, NamedCharacterSpaces.Digits, ExpectedResult = "10")]
        [TestCase((ulong)1, NamedCharacterSpaces.UpperLatinLetters, ExpectedResult = "B")]
        [TestCase((ulong)10, NamedCharacterSpaces.UpperLatinLetters, ExpectedResult = "K")]
        [TestCase((ulong)25, NamedCharacterSpaces.UpperLatinLetters, ExpectedResult = "Z")]
        [TestCase((ulong)26, NamedCharacterSpaces.UpperLatinLetters, ExpectedResult = "BA")]
        [TestCase((ulong)27, NamedCharacterSpaces.UpperLatinLetters, ExpectedResult = "BB")]
        public string ConvertTests(ulong code, string charSpace)
        {
            var characterSpace = new Encoder(charSpace);
            return characterSpace.Convert(code);
        }
        
        [TestCase((ulong)1, NamedCharacterSpaces.Digits, ExpectedResult = "001")]
        [TestCase((ulong)10, NamedCharacterSpaces.Digits, ExpectedResult = "010")]
        [TestCase((ulong)1, NamedCharacterSpaces.UpperLatinLetters, ExpectedResult = "AAB")]
        [TestCase((ulong)10, NamedCharacterSpaces.UpperLatinLetters, ExpectedResult = "AAK")]
        [TestCase((ulong)25, NamedCharacterSpaces.UpperLatinLetters, ExpectedResult = "AAZ")]
        [TestCase((ulong)26, NamedCharacterSpaces.UpperLatinLetters, ExpectedResult = "ABA")]
        [TestCase((ulong)27, NamedCharacterSpaces.UpperLatinLetters, ExpectedResult = "ABB")]
        public string ConvertWithFixedWidthTests(ulong code, string charSpace)
        {
            var characterSpace = new Encoder(charSpace);
            return characterSpace.Convert(code, 3);
        }

        [Test]
        public void Convert_WithZeroInput_ThrowsException()
        {
            var cs = new Encoder(NamedCharacterSpaces.Digits);

            Should.Throw<ArgumentException>(() => cs.Convert(0));
        }
    }
}