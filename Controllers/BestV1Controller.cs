using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Versioning.Controllers
{
    //[Route("api/handsomeUser/[action]")]

    //Route for URL versioning
    [Route("api/v{version:apiVersion}/user-v1/[action]")]
    [ApiController]
    [ApiVersion("1")]

    public class BetterController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInfo()
        {
            return Ok("This is the V1 controller handsome");
        }
    }
}
