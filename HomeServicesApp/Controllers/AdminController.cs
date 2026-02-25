//using HomeServicesApp.Data;
//using HomeServicesApp.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace HomeServicesApp.Controllers
//{
//    public class AdminController : Controller
//    {
//        private readonly AppDbContext _context;

//        public AdminController(AppDbContext context)
//        {
//            _context = context;
//        }

//        public IActionResult Dashboard()
//        {
//            return View();

//        }

//        public IActionResult Users()
//        {

//            return View();
//        }

//        public IActionResult Workers()
//        {
//            return View();
//        }

//        public IActionResult Bookings()
//        {
//            return View();
//        }

//        public IActionResult Revenue()
//        {

//            return View();
//        }



//        //// Show all services

//        //public IActionResult Index()
//        //{
//        //    var services = _context.Services.ToList();
//        //    return View(services);
//        //}

//        //// Add service form
//        //// ➕ ADD SERVICE (GET)
//        //public IActionResult AddService()
//        //{
//        //    return View();
//        //}

//        //// ➕ ADD SERVICE (POST)
//        //[HttpPost]
//        //public IActionResult AddService(Service service)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        _context.Services.Add(service);
//        //        _context.SaveChanges();
//        //        return RedirectToAction("Index");
//        //    }

//        //    return View(service);
//        //}

//        //// ✏ EDIT SERVICE (GET)
//        //[HttpGet]
//        //public IActionResult Edit(int id)
//        //{
//        //    var service = _context.Services.Find(id);

//        //    if (service == null)
//        //        return NotFound();

//        //    return View(service);
//        //}
//        //// ✏ EDIT SERVICE (POST)
//        //[HttpPost]
//        //public IActionResult Edit(Service service)
//        //{
//        //    _context.Services.Update(service);
//        //    _context.SaveChanges();
//        //    return RedirectToAction("Index");
//        //}

//        //// 🗑 DELETE SERVICE
//        //public IActionResult Delete(int id)
//        //{
//        //    var service = _context.Services.Find(id);

//        //    if (service == null)
//        //        return NotFound();

//        //    _context.Services.Remove(service);
//        //    _context.SaveChanges();

//        //    return RedirectToAction("Index");
//        //}
//    }
//}


using HomeServicesApp.Data;
using HomeServicesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeServicesApp.Controllers
{
    public class AdminController : Controller
    { 
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public AdminController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

<<<<<<< HEAD
        // Show all servicesv
        public IActionResult Index()
        {
            var services = _context.Services.ToList();
            return View(services);
        }

        // Add service form
        // ➕ ADD SERVICE (GET)
        public IActionResult AddService() 
=======
        // ===============================
        // DASHBOARD
        // ===============================
        public IActionResult Dashboard()
>>>>>>> 21d814be76e80bb463d09acdb39b67f7bdca3a29
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Workers()
        {
            return View();
        }

        public IActionResult Bookings()
        {
            return View();
        }

        public IActionResult Revenue()
        {
            return View();
        }

        // =====================================================
        // ================= SERVICE MANAGEMENT =================
        // =====================================================

        // 🔹 Show all services
        public async Task<IActionResult> Services()
        {
            var services = await _context.Services.ToListAsync();
            return View(services);
        }

        // 🔹 Add Service (GET)
        public IActionResult CreateService()
        {
            return View();
        }

        // 🔹 Add Service (POST)
        [HttpPost]
        public async Task<IActionResult> CreateService(Service service, IFormFile? IconFile)
        {
            if (ModelState.IsValid)
            {
                if (IconFile != null)
                {
                    string uploadFolder = Path.Combine(_environment.WebRootPath, "uploads");

                    if (!Directory.Exists(uploadFolder))
                        Directory.CreateDirectory(uploadFolder);

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(IconFile.FileName);
                    string filePath = Path.Combine(uploadFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await IconFile.CopyToAsync(stream);
                    }

                    service.IconPath = "/uploads/" + fileName;
                }

                _context.Services.Add(service);
<<<<<<< HEAD
                _context.SaveChanges(); 
                return RedirectToAction("Index");
=======
                await _context.SaveChangesAsync();
                return RedirectToAction("Services");
>>>>>>> 21d814be76e80bb463d09acdb39b67f7bdca3a29
            }

            return View(service);
        }

        // 🔹 Edit Service (GET)
        public async Task<IActionResult> EditService(int id)
        {
            var service = await _context.Services.FindAsync(id);

            if (service == null)
                return NotFound();

            return View(service);
        }

        // 🔹 Edit Service (POST)
        [HttpPost]
        public async Task<IActionResult> EditService(Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Update(service);
                await _context.SaveChangesAsync();
                return RedirectToAction("Services");
            }

            return View(service);
        }

        // 🔹 Delete Service
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