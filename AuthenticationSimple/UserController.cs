using Microsoft.AspNetCore.Mvc;

namespace AuthenticationSimple
{
    [Route("/login")]
    public class UserController : ControllerBase
    {
        private readonly JwtCreator _jwtCreator;

        public UserController(JwtCreator jwtCreator)
        {
            _jwtCreator = jwtCreator;
        }

        [HttpPost("password")]
        public async Task<IActionResult> Post([FromBody] LoginRequest request)
        {
            if (request.AppointmentPersonName == "Patient")
                return Ok(_jwtCreator.GenerateJsonWebToken("Patient"));
            return Unauthorized();
        }
    }
}
