using System.Collections.Generic;

namespace Stravaig.ShortCode
{
    public interface IShortCodeFactory
    {
        string GetNextCode();
        IEnumerable<string> GetCodes(int number);
    }
}