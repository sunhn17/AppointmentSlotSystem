using ManagementDoctor.Database;
using ManagementDoctor.Repositories;
using ManagementDoctor.Serivices;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ManagementDoctor
{
    public static class Extensions
    {
        public static IServiceCollection AddManagementModule(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddTransient<CreatDoctorSlot>()
               .AddTransient<IDoctorRepository, DoctorSlotRepo>();

            services.AddDbContext<TimeAppointDb>(options =>
            {
                options.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = database_for_appointment");
            });

            return services;
        }
        public static IApplicationBuilder UseManagementModule(this IApplicationBuilder app) 
        {
            return app;
        
        }
    }
}