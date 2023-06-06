using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management.Controllers.MVC
{
    public class HospitalController : Controller
    {
        public IActionResult Form()
        {
            return View();
        } 
        public IActionResult LoginForm()
        {
            return View();
        }
    }
}
