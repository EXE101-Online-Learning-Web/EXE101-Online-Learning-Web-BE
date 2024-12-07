using Microsoft.AspNetCore.Mvc;
using OnlineLearningWebAPI.DTOs;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        // GET: api/teachers/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacher(int id)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id);
            if (teacher == null) return NotFound(new { message = "[TeacherController] | GetTeacher | Teacher not found" });

            return Ok(teacher); 
        }

        // PUT: api/teachers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] TeacherDTO teacherDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var isUpdated = await _teacherService.UpdateTeacherAsync(id, teacherDTO);
            if (!isUpdated) return NotFound(new { message = "[TeacherController] | GetTeacher | Teacher not found" });

            return NoContent();
        }
    }
}
