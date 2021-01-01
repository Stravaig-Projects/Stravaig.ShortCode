using NUnit.Framework;

namespace Stravaig.ShortCode.Tests
{
    [TestFixture]
    public class RandomCodeGeneratorTests : CodeGeneratorTestsBase
    {
        protected override IShortCodeGenerator GetGenerator(string testName = null)
        {
            return new RandomCodeGenerator();
        }
    }
}