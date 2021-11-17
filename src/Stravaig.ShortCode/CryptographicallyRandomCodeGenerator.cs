using System;
using System.Security.Cryptography;

namespace Stravaig.ShortCode
{
    public class CryptographicallyRandomCodeGenerator : IShortCodeGenerator
    {
        #if !NET6_0
        private readonly RNGCryptoServiceProvider _rng;
        #endif

        public CryptographicallyRandomCodeGenerator()
        {
            #if !NET6_0
            _rng = new RNGCryptoServiceProvider();
            #endif
        }
        public ulong GetNextCode()
        {
            byte[] bytes = new byte[8];
            #if NET6_0
            RandomNumberGenerator.Fill(bytes);
            #else
            _rng.GetBytes(bytes);
            #endif
            return BitConverter.ToUInt64(bytes, 0);
        }
    }
}