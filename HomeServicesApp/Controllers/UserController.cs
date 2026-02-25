using Microsoft.AspNetCore.Mvc;

namespace HomeServicesApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Bookservices()
        {
            return View();
        }
    }
}
