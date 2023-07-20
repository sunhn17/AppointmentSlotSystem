using ManagementDoctor.Entities;

namespace ManagementDoctor.Repositories
{
    public class DoctorSlotInMemoryRepo : IDoctorRepository
    {
        private static readonly List<DoctorTimeSlot> DoctorTimeSlots = new();
        public async Task Add(DoctorTimeSlot doctorTimeSlot)
        {
            DoctorTimeSlots.Add(doctorTimeSlot);
        }
    }
}
