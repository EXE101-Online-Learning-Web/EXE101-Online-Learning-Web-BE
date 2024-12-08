using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineLearningWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [Authorize(AuthenticationSchemes = "Bearer", Policy = "RequireAdminRole")]
        [HttpGet("ProtectedEndpoint")]
        public IActionResult GetProtectedData()
        {
            return Ok(new { Message = "This is a protected endpoint!" });
        }
    }
}
