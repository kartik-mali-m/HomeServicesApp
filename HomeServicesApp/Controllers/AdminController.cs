using HomeServicesApp.Data;
using HomeServicesApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeServicesApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public AdminController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // ===============================
        // DASHBOARD
        // ===============================
        public async Task<IActionResult> Dashboard()
        {
            ViewBag.TotalWorkers = await _context.Workers.CountAsync();
            ViewBag.TotalServices = await _context.Services.CountAsync();
            ViewBag.TotalBookings = await _context.Bookings.CountAsync();

            return View();
        }

        // ===============================
        // USERS (placeholder)
        // ===============================
        public IActionResult Users()
        {
            return View();
        }

        // ===============================
        // WORKER MANAGEMENT
        // ===============================
        public async Task<IActionResult> Workers()
        {
            var workers = await _context.Workers
                .OrderBy(w => w.IsApproved)
                .ThenBy(w => w.Name)
                .ToListAsync();

            return View(workers);
        }

        public async Task<IActionResult> ApproveWorker(int id)
        {
            var worker = await _context.Workers.FindAsync(id);

            if (worker != null)
            {
                worker.IsApproved = true;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Workers");
        }

        public async Task<IActionResult> RejectWorker(int id)
        {
            var worker = await _context.Workers.FindAsync(id);

            if (worker != null)
            {
                worker.IsApproved = false;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Workers");
        }

        // ===============================
        // BOOKINGS (placeholder)
        // ===============================
        public async Task<IActionResult> Bookings()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return View(bookings);
        }

        // ===============================
        // REVENUE (placeholder)
        // ===============================
        public IActionResult Revenue()
        {
            return View();
        }

        // =====================================================
        // ================= SERVICE MANAGEMENT =================
        // =====================================================

        // Show all services
        public async Task<IActionResult> Services()
        {
            var services = await _context.Services.ToListAsync();
            return View(services);
        }

        // Create Service (GET)
        public IActionResult CreateService()
        {
            return View();
        }

        // Create Service (POST)
        [HttpPost]
        public async Task<IActionResult> CreateService(Service service, IFormFile? IconFile)
        {
            if (!ModelState.IsValid)
                return View(service);

            if (IconFile != null)
            {
                string uploadFolder = Path.Combine(_environment.WebRootPath, "uploads");

                if (!Directory.Exists(uploadFolder))
                    Directory.CreateDirectory(uploadFolder);

                string fileName = Guid.NewGuid() + Path.GetExtension(IconFile.FileName);
                string filePath = Path.Combine(uploadFolder, fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await IconFile.CopyToAsync(stream);

                service.IconPath = "/uploads/" + fileName;
            }

            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();

            return RedirectToAction("Services");
        }

        // Edit Service (GET)
        public async Task<IActionResult> EditService(int id)
        {
            var service = await _context.Services.FindAsync(id);

            if (service == null)
                return NotFound();

            return View(service);
        }

        // Edit Service (POST)
        [HttpPost]
        public async Task<IActionResult> EditService(Service service)
        {
            if (!ModelState.IsValid)
                return View(service);

            _context.Services.Update(service);
            await _context.SaveChangesAsync();

            return RedirectToAction("Services");
        }

        // Delete Service
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _context.Services.FindAsync(id);

            if (service == null)
                return NotFound();

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return RedirectToAction("Services");
        }
    }
}