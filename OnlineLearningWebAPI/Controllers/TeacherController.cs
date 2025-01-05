using Microsoft.AspNetCore.Mvc;
using OnlineLearningWebAPI.DTOs.request.TeacherRequest;
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

        // GET: api/teachers/all
        [HttpGet("all")]
        public async Task<IActionResult> GetAllTeachers()
        {
            var teachers = await _teacherService.GetAllTeachersAsync();
            return Ok(teachers);
        }

        // GET: api/teachers/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacher(string id)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id);
            if (teacher == null) return NotFound(new { message = "[TeacherController] | GetTeacher | Teacher not found" });

            return Ok(teacher); 
        }

        // PUT: api/teachers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(string id, [FromBody] UpdateTeacherDTO teacherDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var isUpdated = await _teacherService.UpdateTeacherDetailsAsync(id, teacherDTO);
            if (!isUpdated) return NotFound(new { message = "[TeacherController] | GetTeacher | Teacher not found" });

            return NoContent();
        }
    }
}
