using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace NotificationSimple
{
    public static class Extensions
    {
        public static IServiceCollection AddNotificationModule(this IServiceCollection services) 
        {
            services.AddHttpLogging(options => 
            {
                options.LoggingFields = HttpLoggingFields.All;
             });
            services.AddTransient<LogNotification>();

            return services;
        }
    }
}