using Booking.Domain.Contracts;
using Booking.Domain.Entities;

namespace Booking.Infrastructure.Repositories
{
    public class PatientAppointInMemoryRepo : IPatientRepository
    {
        private static readonly List<PatientAppointSlot> PatientAppointSlots = new();
        public async Task Add(PatientAppointSlot patientTimeSlot)
        {
            PatientAppointSlots.Add(patientTimeSlot);
        }
    }
}
