using HomeServicesApp.Data;
using HomeServicesApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeServicesApp.Controllers
{
    public class AdminController : Controller
    { 
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // Show all servicesv
        public IActionResult Index()
        {
            var services = _context.Services.ToList();
            return View(services);
        }

        // Add service form
        // ➕ ADD SERVICE (GET)
        public IActionResult AddService() 
        {
            return View();
        }

        // ➕ ADD SERVICE (POST)
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Add(service);
                _context.SaveChanges(); 
                return RedirectToAction("Index");
            }

            return View(service);
        }

        // ✏ EDIT SERVICE (GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var service = _context.Services.Find(id);

            if (service == null)
                return NotFound();

            return View(service);
        }
        // ✏ EDIT SERVICE (POST)
        [HttpPost]
        public IActionResult Edit(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // 🗑 DELETE SERVICE
        public IActionResult Delete(int id)
        {
            var service = _context.Services.Find(id);

            if (service == null)
                return NotFound();

            _context.Services.Remove(service);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}