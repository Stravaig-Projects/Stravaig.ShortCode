using System;
using System.Security.Cryptography;

namespace Stravaig.ShortCode
{
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
}