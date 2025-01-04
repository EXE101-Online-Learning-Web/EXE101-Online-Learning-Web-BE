using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public CourseController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        // GET: api/teachers/{id}
        [HttpGet()]
        public async Task<IActionResult> GetAllCourses()
        {
            var _courseService = _serviceProvider.GetService<ICourseService>();

            List<Course> allCourses = await _courseService.GetAllCourse();

            if (allCourses == null || allCourses.Count == 0) return NotFound(new { message = "[CourseController] | GetAllCourses | Course not found" });

            return Ok(allCourses);
        }

        // GET: api/teachers/{id}
        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetCourseById(int courseId)
        {
            var _courseService = _serviceProvider.GetService<ICourseService>();

            Course course = await _courseService.GetCourseById(courseId);

            if (course == null) return NotFound(new { message = "[CourseController] | GetCourseById | Course not found" });

            return Ok(course);
        }
    }
}
