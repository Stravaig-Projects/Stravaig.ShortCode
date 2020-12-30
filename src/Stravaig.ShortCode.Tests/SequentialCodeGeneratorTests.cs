using NUnit.Framework;
using Shouldly;

namespace Stravaig.ShortCode.Tests
{
    [TestFixture]
    public class SequentialCodeGeneratorTests : CodeGeneratorTestsBase
    {
        [Test]
        public void SeedZero_GetNextCode_IncrementsByOneEachTime()
        {
            var gen = new SequentialCodeGenerator(0);
            gen.GetNextCode().ShouldBe(1UL);
            gen.GetNextCode().ShouldBe(2UL);
            gen.GetNextCode().ShouldBe(3UL);
        }

        [Test]
        public void SingleThreadStressTest()
        {
            var gen = new SequentialCodeGenerator(0);
            SingleThreadStressTest(gen);
        }

        [Test]
        public void MultiThreadStressTest()
        {
            var gen = new SequentialCodeGenerator(0);
            MultiThreadStressTest(gen);
        }
    }
}