using Booking.Application.Dtos;
using Booking.Application.Usecases;
using ManagementDoctor.Database;
using ManagementDoctor.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace NotificationSimple;

    public class LogNotification
{
    private readonly ILogger<LogNotification> _logger;

    public LogNotification(ILogger<LogNotification> logger)
    {
        _logger = logger;
    }

    public Task Execute(CreatePatientAppRequest appointslot, DoctorTimeSlot appointmentSlot)
    {

        _logger.LogInformation("Appointment from Patient: ${PatientName}", appointslot.PatientName);
        _logger.LogInformation("Appointment time: ${ReservedAt}", appointslot.ReservedAt);
        _logger.LogInformation("Appointment to Doctor name: ${DoctorName}", appointmentSlot.DoctorName);

        return Task.CompletedTask;

    }
}

