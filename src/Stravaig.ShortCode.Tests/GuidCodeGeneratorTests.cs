using NUnit.Framework;

namespace Stravaig.ShortCode.Tests
{
    [TestFixture]
    public class GuidCodeGeneratorTests : CodeGeneratorTestsBase
    {
        [Test]
        public void SingleThreadStressTest()
        {
            var gen = new GuidCodeGenerator();
            SingleThreadStressTest(gen);
        }

        [Test]
        public void MultiThreadStressTest()
        {
            var gen = new GuidCodeGenerator();
            MultiThreadStressTest(gen);
        }
    }
}