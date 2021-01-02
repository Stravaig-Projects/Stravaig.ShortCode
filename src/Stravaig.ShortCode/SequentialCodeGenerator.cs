using System;
using System.Linq;
using Microsoft.Extensions.Options;

namespace Stravaig.ShortCode
{
    public class SequentialCodeGenerator : IShortCodeGenerator
    {
        private const string OptionsSeedKey = "seed";
        private ulong _code;
        private readonly object _syncLock = new object();

        public SequentialCodeGenerator()
            : this(0)
        {
        }
        
        public SequentialCodeGenerator(ulong seed)
        {
            _code = seed;
        }

        public SequentialCodeGenerator(ShortCodeOptions options)
            : this(GetSeed(options))
        {
        }

        public SequentialCodeGenerator(IOptions<ShortCodeOptions> options)
            : this(options.Value)
        {
        }

        private static ulong GetSeed(ShortCodeOptions options)
        {
            var key = options.Generator.Keys
                .FirstOrDefault(k => k.Equals(OptionsSeedKey, StringComparison.OrdinalIgnoreCase));
            if (key == null)
                return 0UL;
            var rawValue = options.Generator[key];
            if (rawValue is string stringValue)
                return Convert.ToUInt64(stringValue);
            return (ulong) rawValue;
        }
        
        public ulong GetNextCode()
        {
            lock (_syncLock)
            {
                return ++_code;
            }
        }
    }
}