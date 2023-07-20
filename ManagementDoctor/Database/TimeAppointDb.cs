using ManagementDoctor.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ManagementDoctor.Database
{
    public class TimeAppointDb : DbContext
    {
        public DbSet<DoctorTimeSlot> TimeSlot_SHN { get; set; }

        public TimeAppointDb(DbContextOptions<TimeAppointDb> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("database_for_appointment");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }


}
