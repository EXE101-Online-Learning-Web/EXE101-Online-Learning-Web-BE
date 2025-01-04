using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningWebAPI.DTOs;
using OnlineLearningWebAPI.DTOs.request.ProfileRequest;
using OnlineLearningWebAPI.DTOs.response;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public ProfileController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // GET: api/teachers/{id}
        [HttpGet("{accountId}")]
        public IActionResult GetProfileByAccountId(string accountId)
        {
            var _profileService = _serviceProvider.GetService<IProfileService>();

            Profile profile = _profileService.GetProfileByAccountId(accountId);

            if (profile == null) return NotFound(new { message = "[ProfileController] | GetProfileByAccountId | Profile not found" });

            return Ok(profile);
        }

        // PUT: api/teachers/{id}
        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequest updateProfileDTO)
        {
            var _profileService = _serviceProvider.GetService<IProfileService>();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            GeneralResponse response = await _profileService.UpdateProfile(updateProfileDTO);

            if (!response.Flag) return NotFound(new { message = "[ProfileController] | UpdateProfile |" + response.Message });

            return Ok(response);
        }

        // PUT: api/teachers/{id}
        [HttpPost]
        public async Task<IActionResult> PostProfile([FromBody] AddProfileRequest addProfileDTO)
        {
            var _profileService = _serviceProvider.GetService<IProfileService>();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            GeneralResponse response = await _profileService.AddNewProfile(addProfileDTO);

            if (!response.Flag) return NotFound(new { message = "[ProfileController] | PostProfile |" + response.Message });

            return Ok(response);
        }
    }
}
