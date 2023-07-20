using ManagementDoctor.Entities;

namespace ManagementDoctor.Repositories
{
    public interface IDoctorRepository
    {
        public Task Add(DoctorTimeSlot doctorTimeSlot);
    }
}
