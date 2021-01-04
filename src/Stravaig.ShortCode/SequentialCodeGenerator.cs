using System;
using System.Linq;
using Microsoft.Extensions.Options;
using Stravaig.ShortCode.Internal;

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
            return options.GetGeneratorUInt64(OptionsSeedKey);
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