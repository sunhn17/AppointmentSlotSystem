using Booking.Application.Dtos;
using Booking.Domain.Contracts;
using Booking.Domain.Entities;
using Booking.Domain.Exceptions;

namespace Booking.Application.Usecases
{
    public class CreatPatientAppoint
    {
        private readonly IPatientRepository _patientRepository;
        public CreatPatientAppoint(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task Execute(CreatePatientAppRequest request)
        {
            if (string.IsNullOrEmpty(request.PatientName))
            {
                throw new PatientNameEmptyExistsException();
            }

            var slot = new PatientAppointSlot { Id = request.Id, SlotId = request.SlotId, PatientId = request.PatientId, PatientName = request.PatientName, ReservedAt = request.ReservedAt };

            await _patientRepository.Add(slot);
        }
    }
}
