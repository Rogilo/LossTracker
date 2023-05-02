using Microsoft.AspNetCore.Mvc;

namespace RunDietSystem.Controllers
{
    public class RationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
