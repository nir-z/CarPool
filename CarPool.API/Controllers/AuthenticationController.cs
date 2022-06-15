using CarPool.BL.Authentication;
using CarPool.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CarPool.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerApiBase
    {
        private readonly IAuthenticationManager _authenticationManager;


        public AuthenticationController(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        [HttpPost("token")]
        public ActionResult<JWT> Authenticate(LoginRequest loginRequest)
        {
            return Ok(_authenticationManager.Authenticate(loginRequest));
        }
    }
}
