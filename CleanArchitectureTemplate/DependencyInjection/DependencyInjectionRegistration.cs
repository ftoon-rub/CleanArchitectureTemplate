using System.Runtime.CompilerServices;

namespace CleanArchitectureTemplate.DependencyInjection
{
    public static class DependencyInjectionRegistration
    {
        public static IServiceCollection CustomServicesInjection(this IServiceCollection services )
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
