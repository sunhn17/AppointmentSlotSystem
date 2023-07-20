using Booking.Application.Dtos;
using Booking.Application.Usecases;
using ManagementDoctor.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NotificationSimple;
using System.Text.Json;

namespace Booking.API.Controllers
{
    [Controller]
    [Route("/Patient")]
    [Authorize]
    public class PatientController : ControllerBase
    {
        private readonly CreatPatientAppoint _creatPatientAppoint;
        private TimeAppointDb _SlotDB;
        private LogNotification _logNotification;


        public PatientController(TimeAppointDb SlotDB, CreatPatientAppoint creatPatientAppoint, LogNotification logNotification)
        {
            _SlotDB = SlotDB;
            _creatPatientAppoint = creatPatientAppoint;
            _logNotification = logNotification;
        }

        [HttpGet("getslots")]
        public async Task<IActionResult> Get([FromHeader] string? name)
        {
            var timeslot = await _SlotDB.TimeSlot_SHN.Where(item => item.IsReserved == false).ToListAsync();

            if (timeslot.Count == 0)
            {
                return Ok("Appointment Slot Not Found!");
            }

            return Ok(timeslot);

        }
        [HttpPost("postslots")]
        public async Task<IActionResult> PostAsync([FromBody] CreatePatientAppRequest appointslot)
        {
            Console.WriteLine(JsonSerializer.Serialize(HttpContext.Request.Headers));
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(error => error.ErrorMessage)
                    .ToList();
                return BadRequest(errors);
            }

            var appointmentSlot = await _SlotDB.TimeSlot_SHN.FindAsync(appointslot.SlotId);

            await _logNotification.Execute(appointslot, appointmentSlot);

            await _creatPatientAppoint.Execute(appointslot);

            return Ok("Appointment Succeful!");
        }
    }
}
