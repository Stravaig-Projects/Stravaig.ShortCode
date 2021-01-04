using System;
using System.Linq;

namespace Stravaig.ShortCode.Internal
{
    internal static class ShortCodeOptionsExtensions
    {
        internal static object GetGeneratorValue(this ShortCodeOptions options, string key)
        {
            var canonicalKey = options.Generator.Keys
                .FirstOrDefault(k => k.Equals(key, StringComparison.OrdinalIgnoreCase));
            if (canonicalKey == null)
                return null;
            return options.Generator[canonicalKey];
        }
        
        internal static ulong GetGeneratorUInt64(this ShortCodeOptions options, string key)
        {
            var rawValue = options.GetGeneratorValue(key);
            switch (rawValue)
            {
                case null:
                    return 0UL;
                case string stringValue:
                    return Convert.ToUInt64(stringValue);
                default:
                    return (ulong) Convert.ChangeType(rawValue, TypeCode.UInt64);
            }
        }
        
        internal static int GetGeneratorInt32(this ShortCodeOptions options, string key)
        {
            var rawValue = options.GetGeneratorValue(key);
            switch (rawValue)
            {
                case null:
                    return 0;
                case string stringValue:
                    return Convert.ToInt32(stringValue);
                default:
                    return (int) Convert.ChangeType(rawValue, TypeCode.Int32);
            }
        }
    }
}