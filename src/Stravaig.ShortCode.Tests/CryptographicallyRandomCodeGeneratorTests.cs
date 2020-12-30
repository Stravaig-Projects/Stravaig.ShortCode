using NUnit.Framework;

namespace Stravaig.ShortCode.Tests
{
    [TestFixture]
    public class CryptographicallyRandomCodeGeneratorTests : CodeGeneratorTestsBase
    {
        [Test]
        public void SingleThreadStressTest()
        {
            var gen = new CryptographicallyRandomCodeGenerator();
            SingleThreadStressTest(gen);
        }

        [Test]
        public void MultiThreadStressTest()
        {
            var gen = new CryptographicallyRandomCodeGenerator();
            MultiThreadStressTest(gen);
        }
    }
}