namespace Stravaig.ShortCode
{
    public class SequentialCodeGenerator : IShortCodeGenerator
    {
        private ulong _code;
        private readonly object _syncLock = new object();
        
        public SequentialCodeGenerator(ulong seed)
        {
            _code = seed;
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