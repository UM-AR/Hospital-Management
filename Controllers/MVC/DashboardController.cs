using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management.Controllers.MVC
{
    public class DashboardController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
