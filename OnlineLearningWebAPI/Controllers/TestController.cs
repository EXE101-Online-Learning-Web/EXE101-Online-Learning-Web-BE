using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineLearningWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("ProtectedEndpoint")]
        public IActionResult GetProtectedData()
        {
            return Ok(new { Message = "This is a protected endpoint!" });
        }
    }
}
