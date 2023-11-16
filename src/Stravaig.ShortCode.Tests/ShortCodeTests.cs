using System;
using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using Stravaig.Jailbreak;

namespace Stravaig.ShortCode.Tests
{
    [TestFixture]
    public class ShortCodeTests
    {
        [SetUp]
        public void Reset()
        {
            dynamic shortCode = typeof(ShortCode).Jailbreak();
            shortCode.Init();
        }

        [Test]
        public void DefaultSettings_HappyPath()
        {
            var sequentialCode1 = ShortCode.GenerateSequentialShortCode();
            sequentialCode1.Length.ShouldBe(7);
            sequentialCode1.ShouldBe("aaaaaab");
            
            var sequentialCode2 = ShortCode.GenerateSequentialShortCode();
            sequentialCode2.Length.ShouldBe(7);
            sequentialCode2.ShouldBe("aaaaaac");

            var randomCode1 = ShortCode.GenerateRandomShortCode();
            randomCode1.Length.ShouldBe(7);

            var randomCode2 = ShortCode.GenerateRandomShortCode();
            randomCode2.Length.ShouldBe(7);
            randomCode1.ShouldNotBe(randomCode2);
        }

        [Test]
        public void YouTubeStyleSettings_HappyPath()
        {
            ShortCode.InitYouTubeStyle(resetGenerators: true);

            var sequentialCode1 = ShortCode.GenerateSequentialShortCode();
            sequentialCode1.Length.ShouldBe(11);
            sequentialCode1.ShouldBe("AAAAAAAAAAB");
            
            var sequentialCode2 = ShortCode.GenerateSequentialShortCode();
            sequentialCode2.Length.ShouldBe(11);
            sequentialCode2.ShouldBe("AAAAAAAAAAC");

            var randomCode1 = ShortCode.GenerateRandomShortCode();
            randomCode1.Length.ShouldBe(11);

            var randomCode2 = ShortCode.GenerateRandomShortCode();
            randomCode2.Length.ShouldBe(11);
            randomCode1.ShouldNotBe(randomCode2);
        }
        
        [Test]
        [TestCaseSource(sourceName: nameof(Lengths))]
        public void SetLength_HappyPath(int length)
        {
            ShortCode.SetDefaultLength(length);
            
            var sequentialCode = ShortCode.GenerateSequentialShortCode();
            sequentialCode.Length.ShouldBe(length);
            
            var randomCode = ShortCode.GenerateRandomShortCode();
            randomCode.Length.ShouldBe(length);
        }
        
        [Test]
        [TestCase(10UL, "aaaaaal")]
        [TestCase(100UL, "aaaaabN")]
        public void SetSequentialSeed_HappyPath(ulong seed, string value)
        {
            ShortCode.SetSequentialSeed(seed);
            var sequentialCode = ShortCode.GenerateSequentialShortCode();
            sequentialCode.ShouldBe(value);
        }

        [Test]
        [TestCase("0001111", "01")]
        [TestCase("AAABBBB", "AB")]
        [TestCase("AAAAADD", "ABCD")]
        [TestCase("0000030", "01234")]
        public void SetCharacterSpace_HappyPath(string value, string characterSpace)
        {
            ShortCode.SetSequentialSeed(14UL);
            ShortCode.SetCharacterSpace(characterSpace);
            var sequentialCode = ShortCode.GenerateSequentialShortCode();
            sequentialCode.ShouldBe(value);
        }

        [Test]
        public void Use_SetsTheInternalGeneratorToRandom()
        {
            ShortCode.Use<RandomCodeGenerator>();
            dynamic shortCode = typeof(ShortCode).Jailbreak();
            IShortCodeGenerator generator = (IShortCodeGenerator)shortCode._randomGenerator;

            generator.ShouldNotBeNull();
            generator.ShouldBeOfType(typeof(RandomCodeGenerator));
        }
        
        [Test]
        public void Use_SetsTheInternalGeneratorToGuid()
        {
            ShortCode.Use<GuidCodeGenerator>();
            dynamic shortCode = typeof(ShortCode).Jailbreak();
            IShortCodeGenerator generator = (IShortCodeGenerator)shortCode._randomGenerator;

            generator.ShouldNotBeNull();
            generator.ShouldBeOfType(typeof(GuidCodeGenerator));
        }

        [Test]
        public void Use_SetsTheInternalGeneratorToCryptographicallyRandom()
        {
            ShortCode.Use<CryptographicallyRandomCodeGenerator>();
            dynamic shortCode = typeof(ShortCode).Jailbreak();
            IShortCodeGenerator generator = (IShortCodeGenerator)shortCode._randomGenerator;

            generator.ShouldNotBeNull();
            generator.ShouldBeOfType(typeof(CryptographicallyRandomCodeGenerator));
        }

        [Test]
        public void InitYouTubeStyle_ShouldSetupForYouTubeStyle()
        {
            // arrange
            dynamic shortCode = typeof(ShortCode).Jailbreak();
            var originalRandGenerator = (IShortCodeGenerator)shortCode._randomGenerator;
            var originalSeqGenerator = (IShortCodeGenerator)shortCode._sequentialCodeGenerator;

            // Act
            ShortCode.InitYouTubeStyle();

            // Assert
            ((int)shortCode._defaultLength).ShouldBe(11);
            ((IShortCodeGenerator)shortCode._randomGenerator).ShouldBe(originalRandGenerator);
            ((IShortCodeGenerator)shortCode._sequentialCodeGenerator).ShouldBe(originalSeqGenerator);

            dynamic encoder = ((Encoder)shortCode._encoder).Jailbreak();
            var characterSpace = (string)encoder._characterSpace;
            characterSpace.ShouldBe(NamedCharacterSpaces.UrlSafeBase64);
        }

        [Test]
        public void InitYouTubeStyleWithReset_ShouldSetupForYouTubeStyle()
        {
            // arrange
            dynamic shortCode = typeof(ShortCode).Jailbreak();
            var originalRandGenerator = (IShortCodeGenerator)shortCode._randomGenerator;
            var originalSeqGenerator = (IShortCodeGenerator)shortCode._sequentialCodeGenerator;

            // Act
            ShortCode.InitYouTubeStyle(resetGenerators: true);

            // Assert
            ((int)shortCode._defaultLength).ShouldBe(11);
            ((IShortCodeGenerator)shortCode._randomGenerator).ShouldNotBe(originalRandGenerator);
            ((IShortCodeGenerator)shortCode._sequentialCodeGenerator).ShouldNotBe(originalSeqGenerator);

            dynamic encoder = ((Encoder)shortCode._encoder).Jailbreak();
            var characterSpace = (string)encoder._characterSpace;
            characterSpace.ShouldBe(NamedCharacterSpaces.UrlSafeBase64);
        }

        private static IEnumerable<int> Lengths()
        {
            for (int i = 1; i <= 9; i++)
                yield return i;
        }
    }
}