using System;
using System.Security.Cryptography;

namespace Stravaig.ShortCode
{
    public class CryptographicallyRandomCodeGenerator : IShortCodeGenerator
    {
        public ulong GetNextCode()
        {
            byte[] bytes = new byte[8];
            RandomNumberGenerator.Fill(bytes);
            return BitConverter.ToUInt64(bytes, 0);
        }
    }
}