using ApplicationLayer.Interfaces.InfrastructureLayer;
using InfrastructureLayer.DAL;
using InfrastructureLayer.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DependencyInjection
{
    public static class InfrastructureLayerDependencyInjectionRegistrations
    {
        public static IServiceCollection InfrastructureLayerServicesInjection(this IServiceCollection services)
        {
            #region AddTransient
            #endregion

            #region AddScoped
            services.AddScoped<IEmailService,EmailService>();
            services.AddScoped<ISmsService,SmsService>();
            services.AddScoped<IRedisCache,RedisCache>();
            services.AddScoped<IStoredProcedures,StoredProcedures>();
            #endregion

            #region AddSingleton
            #endregion

            return services;
        }

    }
}
