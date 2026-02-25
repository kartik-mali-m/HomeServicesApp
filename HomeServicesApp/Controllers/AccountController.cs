using HomeServicesApp.Data;
using HomeServicesApp.Models;
using HomeServicesApp.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HomeServicesApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        // ==========================
        // CUSTOMER REGISTER
        // ==========================
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                return View(model);
            }

            await _userManager.AddToRoleAsync(user, "Customer");

            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
        }

        // ==========================
        // LOGIN
        // ==========================
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(
                user,
                model.Password,
                false,
                false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Invalid login");
                return View(model);
            }

            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("Worker"))
                return RedirectToAction("Dashboard", "Worker");

            if (roles.Contains("Admin"))
                return RedirectToAction("Dashboard", "Admin");

            return RedirectToAction("Index", "Home");
        }

        // ==========================
        // LOGOUT
        // ==========================
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // ==========================
        // WORKER REGISTER
        // ==========================
        public IActionResult RegisterWorker()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterWorker(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                return View(model);
            }

            // Assign Worker role
            await _userManager.AddToRoleAsync(user, "Worker");

            // Create Worker profile
            var worker = new Worker
            {
                UserId = user.Id,
                Name = model.FullName,
                Email = model.Email,
                Phone = model.Phone,
                SkillType = model.SkillType,
                ExperienceYears = model.ExperienceYears,
                ChargesPerHour = model.ChargesPerHour,
                Address = model.Address,
                IsApproved = false,
                IsAvailable = true,
                CreatedAt = DateTime.Now
            };

            _context.Workers.Add(worker);
            await _context.SaveChangesAsync();

            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("Dashboard", "Worker");
        }
    }
}