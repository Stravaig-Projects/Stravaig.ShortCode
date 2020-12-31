using System;
using Microsoft.Extensions.DependencyInjection;
using Stravaig.ShortCode;
using Stravaig.ShortCode.DependencyInjection;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddShortCodeGenerator<GuidCodeGenerator>(options =>
            {
                options.FixedLength = 5;
                options.CharacterSpace = Encoder.LettersAndDigits;
            });

            ServiceProvider provider = services.BuildServiceProvider();
            var factory = provider.GetRequiredService<IShortCodeFactory>();
            
            var code = factory.GetNextCode();
            Console.WriteLine($"GetNextCode: {code}");

            var codes = factory.GetCodes(100);
            foreach (string item in codes)
            {
                Console.WriteLine($"GetCodes: {item}");
            }
        }
    }
}