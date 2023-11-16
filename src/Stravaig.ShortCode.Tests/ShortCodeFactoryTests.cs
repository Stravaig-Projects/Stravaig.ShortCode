using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using Shouldly;
using Stravaig.Extensions.Logging.Diagnostics;

namespace Stravaig.ShortCode.Tests
{
    [TestFixture]
    public class ShortCodeFactoryTests
    {
        [Test]
        public void Ctor_ThrowException_WhenMissingGenerator()
        {
            Should.Throw<ArgumentNullException>(() =>
                new ShortCodeFactory(null, null, (ShortCodeOptions)null, null))
                .ParamName.ShouldBe("generator");
        }
        
        [Test]
        public void Ctor_ThrowException_WhenMissingEncoder()
        {
            Should.Throw<ArgumentNullException>(() =>
                new ShortCodeFactory(new Mock<IShortCodeGenerator>().Object, null, (ShortCodeOptions)null, null))
                .ParamName.ShouldBe("encoder");
        }

        [Test]
        public void Ctor_ThrowException_WhenMissingOptions()
        {
            Should.Throw<ArgumentNullException>(() =>
                new ShortCodeFactory(new Mock<IShortCodeGenerator>().Object, new Mock<IEncoder>().Object, (ShortCodeOptions)null, null))
                .ParamName.ShouldBe("options");
        }

        [Test]
        public void Ctor_ThrowException_WhenMissingLogger()
        {
            Should.Throw<ArgumentNullException>(() =>
                new ShortCodeFactory(new Mock<IShortCodeGenerator>().Object, new Mock<IEncoder>().Object, new ShortCodeOptions(), null))
                .ParamName.ShouldBe("logger");
        }

        [Test]
        public void Ctor_LogsWarning_WhenOptionsAreInconsistent()
        {
            var logger = new TestCaptureLogger<ShortCodeFactory>();
            var options = new ShortCodeOptions
            {
                CharacterSpace = NamedCharacterSpaces.LettersAndDigits,
                FixedLength = 20,
            };
            var encoder = new Encoder(options.CharacterSpace);
            _ = new ShortCodeFactory(new Mock<IShortCodeGenerator>().Object, encoder, options, logger);

            var logs = logger.GetLogs();
            logs.Count.ShouldBe(1);
            Console.WriteLine(logs[0].FormattedMessage);
            logs[0].LogLevel.ShouldBe(LogLevel.Warning);
            logs[0].FormattedMessage.ShouldStartWith("The Short Code generator will always produce codes with padding");
        }

        [Test]
        public void Ctor_IOptionsAndLogger()
        {
            var options = Options.Create( new ShortCodeOptions
            {
                CharacterSpace = NamedCharacterSpaces.LettersAndDigits,
                FixedLength = 5,
            });
            var logger = new TestCaptureLogger<ShortCodeFactory>();
            _ = new ShortCodeFactory(new GuidCodeGenerator(), new Encoder(NamedCharacterSpaces.ReducedAmbiguity), options, logger);
            logger.GetLogs().Count.ShouldBe(0);
        }
        
        [Test]
        public void Ctor_IOptions()
        {
            var options = Options.Create( new ShortCodeOptions
            {
                CharacterSpace = NamedCharacterSpaces.LettersAndDigits,
                FixedLength = 5,
            });
            _ = new ShortCodeFactory(new GuidCodeGenerator(), new Encoder(NamedCharacterSpaces.ReducedAmbiguity), options);
        }

        [Test]
        public void GetNextCode_ShouldReturnCode()
        {
            var options = new ShortCodeOptions
            {
                CharacterSpace = NamedCharacterSpaces.LettersAndDigits,
                FixedLength = 5,
            };
            var factory = new ShortCodeFactory(
                new GuidCodeGenerator(),
                new Encoder(NamedCharacterSpaces.ReducedAmbiguity),
                options,
                new NullLogger<ShortCodeFactory>());

            var result = factory.GetNextCode();
            Console.WriteLine(result);
            result.Length.ShouldBe(5);
        }

        [Test]
        public void GetNextCode_WithYouTubeOptionsShouldYouTubeStyleCode()
        {
            var options = new ShortCodeOptions();
            options.SetYouTubeStyle();

            var factory = new ShortCodeFactory(
                new GuidCodeGenerator(),
                new Encoder(NamedCharacterSpaces.ReducedAmbiguity),
                options,
                new NullLogger<ShortCodeFactory>());

            var result = factory.GetNextCode();
            Console.WriteLine(result);
            result.Length.ShouldBe(11);
        }
        
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(100)]
        public void GetCodes_ShouldReturnRequiredNumberOfCodes(int numberOfCodes)
        {
            var options = new ShortCodeOptions
            {
                CharacterSpace = NamedCharacterSpaces.LettersAndDigits,
                FixedLength = 5,
            };
            var factory = new ShortCodeFactory(
                new GuidCodeGenerator(),
                new Encoder(NamedCharacterSpaces.ReducedAmbiguity),
                options,
                new NullLogger<ShortCodeFactory>());

            var result = factory.GetCodes(numberOfCodes).ToArray();
            result.Length.ShouldBe(numberOfCodes);
            result.Distinct().Count().ShouldBe(numberOfCodes);
        }

    }
}