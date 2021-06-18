using Microsoft.AspNetCore.Mvc;

namespace ProcessPayment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            string thing = null;
            var thingToReturn = thing.ToString();
            return Ok();
        }
    }
}
