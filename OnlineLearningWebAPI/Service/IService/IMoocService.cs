using Microsoft.AspNetCore.Mvc;

namespace OnlineLearningWebAPI.Service.IService
{
    public class IMoocService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
