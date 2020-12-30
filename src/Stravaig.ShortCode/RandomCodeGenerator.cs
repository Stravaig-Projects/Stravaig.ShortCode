using System;

namespace Stravaig.ShortCode
{
    public class RandomCodeGenerator : IShortCodeGenerator
    {
        private readonly Random _rnd;
        private readonly object _syncRoot = new object();
        
        public RandomCodeGenerator()
        {
            _rnd = new Random();
        }
        public ulong GetNextCode()
        {
            byte[] bytes = new byte[8];
            lock (_syncRoot)
            {
                _rnd.NextBytes(bytes);
            }
        
            return BitConverter.ToUInt64(bytes, 0);
        }
        
        // This version produces collisions.
        // After ~4 million iterations: 0.1% of results had collisions
        // After ~67 million iterations: 1.55% of results had collisions.
        // public ulong GetNextCode()
        // {
        //     double value;
        //     lock (_syncRoot)
        //     {
        //         value = _rnd.Next();
        //     }
        //
        //     var bytes = BitConverter.GetBytes(value);
        //     return BitConverter.ToUInt64(bytes, 0);
        // }
    }
}