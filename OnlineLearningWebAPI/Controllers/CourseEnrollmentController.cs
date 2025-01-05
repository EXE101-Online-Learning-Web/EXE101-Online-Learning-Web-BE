using Microsoft.AspNetCore.Mvc;

namespace OnlineLearningWebAPI.Controllers
{
    public class CourseEnrollmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
