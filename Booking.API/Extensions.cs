using Booking.Application.Usecases;
using Booking.Domain.Contracts;
using Booking.Infrastructure.Repositories;
using ManagementDoctor.Database;
using ManagementDoctor.Repositories;
using ManagementDoctor.Serivices;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.API
{
    public static class Extensions
    {
        public static IServiceCollection AddBookingModule(this IServiceCollection services) 
        {
            services.AddTransient<CreatPatientAppoint>()
               .AddTransient<IPatientRepository, PatientAppointRepo>();

            return services;
        }

    }
}