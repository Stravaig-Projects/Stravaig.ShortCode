using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Stravaig.ShortCode.DependencyInjection
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddShortCodeGenerator<TGenerator>(
            this IServiceCollection services,
            Action<ShortCodeOptions> options = null)
            where TGenerator : class, IShortCodeGenerator
        {
            ShortCodeOptions scOptions = new ShortCodeOptions();
            options?.Invoke(scOptions);
            var extOptions = Options.Create(scOptions);
            services.AddSingleton(extOptions);
            
            services.AddCommonParts<TGenerator>();
            return services;
        }
        
        public static IServiceCollection AddShortCodeGenerator<TGenerator>(
            this IServiceCollection services,
            IConfiguration config)
            where TGenerator : class, IShortCodeGenerator
        {
            var shortCodeSection = config.GetSection($"{nameof(Stravaig)}:{nameof(ShortCode)}");
            services.Configure<ShortCodeOptions>(shortCodeSection);
            
            services.AddCommonParts<TGenerator>();
            return services;
        }

        private static void AddCommonParts<TGenerator>(this IServiceCollection services)
            where TGenerator : class, IShortCodeGenerator
        {
            services.AddSingleton<IEncoder>(p =>
            {
                var options = p.GetRequiredService<IOptions<ShortCodeOptions>>();
                return new Encoder(options.Value.CharacterSpace);
            });
            services.AddSingleton<IShortCodeGenerator, TGenerator>();
            services.AddSingleton<IShortCodeFactory, ShortCodeFactory>();
        }
    }
}