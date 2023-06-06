using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management.Controllers.MVC
{
    public class MainPageController : Controller
    {
        public IActionResult MainPage()
        {
            return View();
        }
        public IActionResult Login_User()
        {
            return View();
        }
    }
}
