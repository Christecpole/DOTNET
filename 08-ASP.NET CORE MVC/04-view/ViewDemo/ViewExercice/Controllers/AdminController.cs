using Microsoft.AspNetCore.Mvc;

namespace ViewExercice.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Articles()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Settings()
        {
            return View();
        }
    }
}
