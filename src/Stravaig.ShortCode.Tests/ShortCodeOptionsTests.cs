using System;
using NUnit.Framework;
using Shouldly;

namespace Stravaig.ShortCode.Tests
{
    [TestFixture]
    public class ShortCodeOptionsTests
    {
        [Test]
        public void Ctor_ProducesReasonableValues()
        {
            ShortCodeOptions opts = new ShortCodeOptions();
            opts.Generator.ShouldNotBeNull();
            opts.Generator.ShouldBeEmpty();
            opts.CharacterSpace.ShouldBe(NamedCharacterSpaces.ReducedAmbiguity);
            opts.FixedLength.ShouldBeNull();
            opts.MaxLength.ShouldBe(64);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("      ")]
        [TestCase("A")]
        public void SetCharacterSpace_InvalidValues_ThrowsException(string value)
        {
            Should.Throw<ArgumentException>(() =>
                new ShortCodeOptions()
                {
                    CharacterSpace = value,
                }).ParamName.ShouldBe("CharacterSpace");
        }
        
        [Test]
        [TestCase("AB")]
        [TestCase(NamedCharacterSpaces.LettersAndDigits)]
        public void SetCharacterSpace_ValidValues_GetsSameValue(string value)
        {
            var opts = new ShortCodeOptions()
            {
                CharacterSpace = value,
            };
            opts.CharacterSpace.ShouldBe(value);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(65)]
        public void SetFixedLength_InvalidValues_ThrowsException(int? value)
        {
            Should.Throw<ArgumentException>(() =>
                new ShortCodeOptions()
                {
                    FixedLength = value,
                }).ParamName.ShouldBe("FixedLength");
        }
        
        [Test]
        [TestCase(null)]
        [TestCase(1)]
        [TestCase(64)]
        public void SetFixedLength_ValidValues_GetsSameValue(int? value)
        {
            var opts = new ShortCodeOptions()
            {
                FixedLength = value,
            };
            opts.FixedLength.ShouldBe(value);
        }
        
        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(65)]
        public void SetMaxLength_InvalidValues_ThrowsException(int value)
        {
            Should.Throw<ArgumentException>(() =>
                new ShortCodeOptions
                {
                    MaxLength = value,
                }).ParamName.ShouldBe("MaxLength");
        }
        
        [Test]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(64)]
        public void SetMaxLength_ValidValues_GetsSameValue(int value)
        {
            var opts = new ShortCodeOptions
            {
                MaxLength = value,
            };
            opts.MaxLength.ShouldBe(value);
        }

    }
}