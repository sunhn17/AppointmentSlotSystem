using Booking.Domain.Entities;

namespace Booking.Domain.Contracts
{
    public interface IPatientRepository
    {
        public Task Add(PatientAppointSlot patientAppointSlot);
    }
}
