using System;
using Microsoft.Extensions.DependencyInjection;

namespace Stravaig.ShortCode.DependencyInjection
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddShortCodeGenerator<TGenerator>(this IServiceCollection services, Action<ShortCodeOptions> options)
            where TGenerator : class, IShortCodeGenerator
        {
            ShortCodeOptions scOptions = new ShortCodeOptions();
            options?.Invoke(scOptions);

            services.AddSingleton(options);
            services.AddSingleton<IEncoder>(p => new Encoder(scOptions.CharacterSpace));
            services.AddSingleton<IShortCodeGenerator, TGenerator>();
            services.AddSingleton<IShortCodeFactory, ShortCodeFactory>();
            return services;
        }
    }
}