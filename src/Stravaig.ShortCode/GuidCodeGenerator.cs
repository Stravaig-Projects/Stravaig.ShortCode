using System;

namespace Stravaig.ShortCode
{
    public class GuidCodeGenerator : IShortCodeGenerator
    {
        public ulong GetNextCode()
        {
            var guid = Guid.NewGuid();
            byte[] bytes = guid.ToByteArray();
            ulong a = BitConverter.ToUInt64(bytes, 0);
            ulong b = BitConverter.ToUInt64(bytes, 8);
            return a ^ b;
        }
    }
}