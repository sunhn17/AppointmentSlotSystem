using AuthenticationSimple;
using Booking.API;
using ManagementDoctor;
using Microsoft.Extensions.Configuration;
using NotificationSimple;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services);
});

builder.Services.AddNotificationModule();

builder.Services.AddManagementModule(builder.Configuration);
builder.Services.AddBookingModule();
builder.Services.AddAuthenticationModule(builder.Configuration);

builder.Services.AddControllers();
var app = builder.Build();

app.MapGet("/", () => "Slot Appointment System");
app.UseHttpLogging();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
