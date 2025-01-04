using Microsoft.AspNetCore.Mvc;

namespace OnlineLearningWebAPI.Service.IService
{
    public class IQuizAnswerService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
