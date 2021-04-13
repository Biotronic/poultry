using Biotronic.Poultry.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Biotronic.Poultry.Controllers
{
    public class AuthController : BaseController<AuthController>
    {
        public AuthController(ILogger<AuthController> logger) : base(logger)
        {
        }

        [Route("auth/signin")]
        public IActionResult SignIn([FromBody]string token)
        {
            return Ok();
        }

        [Route("auth/signout")]
        public IActionResult SignOut([FromBody] string token)
        {
            return Ok();
        }
    }
}