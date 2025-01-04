using Microsoft.AspNetCore.Mvc;

namespace OnlineLearningWebAPI.Service.IService
{
    public class IExamTestService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
