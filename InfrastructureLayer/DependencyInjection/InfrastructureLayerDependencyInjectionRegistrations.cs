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
            #endregion

            #region AddSingleton
            #endregion

            return services;
        }

    }
}
