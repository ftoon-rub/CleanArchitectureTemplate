using DomainLayer.Configurations;
using Microsoft.Extensions.Options;

namespace CleanArchitectureTemplate
{
    public static class ConfigurationsReader
    {
        public static IServiceCollection ReadConfigurations( this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettingsConfig>(configuration);
            services.AddSingleton<IAppSettingsConfig>(options => options.GetRequiredService<IOptions<AppSettingsConfig>>().Value);
            return services;
        }
    }
}
