using Microsoft.Extensions.Options;
using NUnit.Framework;
using Shouldly;

namespace Stravaig.ShortCode.Tests
{
    [TestFixture]
    public class SequentialCodeGeneratorTests : CodeGeneratorTestsBase
    {
        [Test]
        public void DefaultCtor_GetNextCode_IncrementsFromOne()
        {
            var gen = new SequentialCodeGenerator();
            gen.GetNextCode().ShouldBe(1UL);
            gen.GetNextCode().ShouldBe(2UL);
            gen.GetNextCode().ShouldBe(3UL);
        }
        
        [Test]
        public void SeedCtor_GetNextCode_IncrementsByOneFromSeedEachTime()
        {
            var gen = new SequentialCodeGenerator(10);
            gen.GetNextCode().ShouldBe(11UL);
            gen.GetNextCode().ShouldBe(12UL);
            gen.GetNextCode().ShouldBe(13UL);
        }
        
        [Test]
        [TestCase("seed", 20)]
        [TestCase("Seed", 20)]
        [TestCase("SEED", 20)]
        [TestCase("seed", "20")]
        [TestCase("Seed", "20")]
        [TestCase("SEED", "20")]
        [TestCase("seed", 20.0)]
        [TestCase("Seed", 20.0)]
        [TestCase("SEED", 20.0)]
        public void ShortCodeOptionsCtor_GetNextCode_IncrementsByOneFromSeedEachTime(string key, object value)
        {
            ShortCodeOptions options = new ShortCodeOptions
            {
                Generator = { [key] = value }
            };
            var gen = new SequentialCodeGenerator(options);
            gen.GetNextCode().ShouldBe(21UL);
            gen.GetNextCode().ShouldBe(22UL);
            gen.GetNextCode().ShouldBe(23UL);
        }

        [Test]
        [TestCase("seed", 20)]
        [TestCase("Seed", 20)]
        [TestCase("SEED", 20)]
        [TestCase("seed", "20")]
        [TestCase("Seed", "20")]
        [TestCase("SEED", "20")]
        [TestCase("seed", 20.0)]
        [TestCase("Seed", 20.0)]
        [TestCase("SEED", 20.0)]
        public void OptionsShortCodeOptionsCtor_GetNextCode_IncrementsByOneFromSeedEachTime(string key, object value)
        {
            ShortCodeOptions scOptions = new ShortCodeOptions
            {
                Generator = { [key] = value }
            };
            var options = Options.Create(scOptions);
            var gen = new SequentialCodeGenerator(options);
            gen.GetNextCode().ShouldBe(21UL);
            gen.GetNextCode().ShouldBe(22UL);
            gen.GetNextCode().ShouldBe(23UL);
        }

        [Test]
        public void ShortCodeOptionsCtorWithoutSeed_GetNextCode_IncrementsByOneFromOne()
        {
            ShortCodeOptions options = new ShortCodeOptions();
            var gen = new SequentialCodeGenerator(options);
            gen.GetNextCode().ShouldBe(1UL);
            gen.GetNextCode().ShouldBe(2UL);
            gen.GetNextCode().ShouldBe(3UL);
        }

        protected override IShortCodeGenerator GetGenerator(string testName = null)
        {
            return new SequentialCodeGenerator(0);
        }
    }
}