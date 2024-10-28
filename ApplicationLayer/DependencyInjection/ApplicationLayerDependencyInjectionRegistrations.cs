using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DependencyInjection
{
    public static class ApplicationLayerDependencyInjectionRegistrations
    {
        public static IServiceCollection ApplicationLayerServicesInjection(this IServiceCollection services)
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
