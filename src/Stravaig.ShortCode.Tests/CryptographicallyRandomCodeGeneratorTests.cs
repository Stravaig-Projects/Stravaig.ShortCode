using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace Stravaig.ShortCode.Tests
{
    [TestFixture]
    public class CryptographicallyRandomCodeGeneratorTests : CodeGeneratorTestsBase
    {
        protected override IShortCodeGenerator GetGenerator([CallerMemberName]string testName = null)
        {
            return new CryptographicallyRandomCodeGenerator();
        }
    }
}