using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Stravaig.ShortCode
{
    public class ShortCodeFactory : IShortCodeFactory
    {
        private readonly IShortCodeGenerator _generator;
        private readonly IEncoder _encoder;
        private readonly ShortCodeOptions _options;
        private readonly ILogger<ShortCodeFactory> _logger;

        public ShortCodeFactory(IShortCodeGenerator generator, IEncoder encoder, ShortCodeOptions options, ILogger<ShortCodeFactory> logger)
        {
            _generator = generator ?? throw new ArgumentNullException(nameof(generator));
            _encoder = encoder ?? throw new ArgumentNullException(nameof(encoder));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            WarnOnInconsistentOptions();
        }

        public ShortCodeFactory(IShortCodeGenerator generator, IEncoder encoder, IOptions<ShortCodeOptions> options,
            ILogger<ShortCodeFactory> logger)
            : this(generator, encoder, options?.Value, logger)
        {
        }

        public ShortCodeFactory(IShortCodeGenerator generator, IEncoder encoder, ShortCodeOptions options)
            : this(generator, encoder, options, NullLogger<ShortCodeFactory>.Instance)
        {
        }

        public ShortCodeFactory(IShortCodeGenerator generator, IEncoder encoder, IOptions<ShortCodeOptions> options)
            : this(generator, encoder, options?.Value)
        {
        }
        
        private void WarnOnInconsistentOptions()
        {
            if (_options.FixedLength.HasValue && _options.FixedLength.Value > _encoder.MaxLength())
                _logger.LogWarning("The Short Code generator will always produce codes with padding because the Fixed Length ({fixedLength}) option is greater than maximum length the encoder can generate ({encoderMaxLength}).",
                    _options.FixedLength.Value,
                    _encoder.MaxLength());
        }


        public string GetNextCode()
        {
            var internalCode = _generator.GetNextCode();
            return _encoder.Convert(internalCode, _options.FixedLength, _options.MaxLength);
        }

        public IEnumerable<string> GetCodes(int number)
        {
            for (int n = 0; n < number; n++)
                yield return GetNextCode();
        }
    }
}