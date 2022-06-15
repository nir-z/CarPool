using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarPool.API.Controllers
{
    [ApiController]
    public abstract class ControllerApiBase : ControllerBase
    {

        [NonAction]
        protected ObjectResult InternalServerErrorResult(Exception ex)
        {
            Console.WriteLine(ex);

            return StatusCode(
                StatusCodes.Status500InternalServerError,
                "Server Error"
            );
        }

    }
}
