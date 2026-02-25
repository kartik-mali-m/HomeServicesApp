using HomeServicesApp.Data;
using HomeServicesApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HomeServicesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            var services = _context.Services.ToList();
            return View(services);
        }

    }
}
