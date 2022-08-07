using System;
using System.Security.Cryptography;

namespace Stravaig.ShortCode
{
#if NET6_0_OR_GREATER
    public class CryptographicallyRandomCodeGenerator : IShortCodeGenerator
    {
        public ulong GetNextCode()
        {
            byte[] bytes = new byte[8];
            RandomNumberGenerator.Fill(bytes);
            return BitConverter.ToUInt64(bytes, 0);
        }
    }

#else // Up to .NET 5.0

    public class CryptographicallyRandomCodeGenerator : IShortCodeGenerator
    {
        private readonly RNGCryptoServiceProvider _rng;

        public CryptographicallyRandomCodeGenerator()
        {
            _rng = new RNGCryptoServiceProvider();
        }
        public ulong GetNextCode()
        {
            byte[] bytes = new byte[8];
            _rng.GetBytes(bytes);
            return BitConverter.ToUInt64(bytes, 0);
        }
    }
#endif
}