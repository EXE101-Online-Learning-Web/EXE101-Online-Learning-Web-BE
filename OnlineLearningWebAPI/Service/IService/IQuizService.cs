using Microsoft.AspNetCore.Mvc;

namespace OnlineLearningWebAPI.Service.IService
{
    public class IQuizService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
