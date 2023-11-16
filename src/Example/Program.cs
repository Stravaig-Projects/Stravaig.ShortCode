using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stravaig.ShortCode;
using Stravaig.ShortCode.DependencyInjection;

namespace Example
{
    class Program
    {
        static void Main()
        {
            var config = BuildConfig();

            ServiceCollection services = new ServiceCollection();
            services.AddYouTubeStyleShortCodeGenerator<RandomCodeGenerator>();
            //services.AddShortCodeGenerator<SequentialCodeGenerator>(config);

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

        private static IConfigurationRoot BuildConfig()
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("appsettings.json");
            var config = configBuilder.Build();
            return config;
        }
    }
}