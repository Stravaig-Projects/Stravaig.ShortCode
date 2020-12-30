using NUnit.Framework;

namespace Stravaig.ShortCode.Tests
{
    [TestFixture]
    public class RandomCodeGeneratorTests : CodeGeneratorTestsBase
    {
        [Test]
        public void SingleThreadStressTest()
        {
            var gen = new RandomCodeGenerator();
            SingleThreadStressTest(gen);
        }

        [Test]
        public void MultiThreadStressTest()
        {
            var gen = new RandomCodeGenerator();
            MultiThreadStressTest(gen);
        }
    }
}