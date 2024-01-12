using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Versioning.Controllers
{
    //[Route("api/handsomeUser/[action]")]

    //Route for URL versioning
    [Route("api/v{version:apiVersion}/user-v2/[action]")]
    [ApiController]
    [ApiVersion("2")]

    public class BestV2Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInfo()
        {
            return Ok("This is the V2 controller handsome");
        }
    }
}
