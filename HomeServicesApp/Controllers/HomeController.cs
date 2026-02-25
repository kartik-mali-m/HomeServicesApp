using HomeServicesApp.Data;
using HomeServicesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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



        //public IActionResult Index()
        //{
        //    //var services = _context.Services.ToList();
        //    return View();
        //}
        public async Task<IActionResult> Index()
        {
            var services = await _context.Services.ToListAsync();

            return View(services);
        }

    }
}
