using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthenticationSimple
{
    public static class Extensions
    {
        public static IServiceCollection AddAuthenticationModule(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));
            services
                .AddSlotAppointmentAuthentication(configuration)
                .AddTransient<JwtCreator>();
            return services;
        }
    }
}