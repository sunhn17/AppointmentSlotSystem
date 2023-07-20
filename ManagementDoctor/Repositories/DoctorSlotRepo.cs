using ManagementDoctor.Database;
using ManagementDoctor.Entities;

namespace ManagementDoctor.Repositories
{
    public class DoctorSlotRepo : IDoctorRepository
    {
        private readonly TimeAppointDb _db;
        public DoctorSlotRepo(TimeAppointDb db)
        {
            _db = db;
        }

        public async Task Add(DoctorTimeSlot doctorTimeSlot)
        {
            _db.TimeSlot_SHN.Add(doctorTimeSlot);
            await _db.SaveChangesAsync();

        }
    }
}
