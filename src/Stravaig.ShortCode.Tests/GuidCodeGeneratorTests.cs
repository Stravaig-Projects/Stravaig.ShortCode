using NUnit.Framework;

namespace Stravaig.ShortCode.Tests
{
    [TestFixture]
    public class GuidCodeGeneratorTests : CodeGeneratorTestsBase
    {
        protected override IShortCodeGenerator GetGenerator(string testName = null)
        {
            return new GuidCodeGenerator();
        }
    }
}