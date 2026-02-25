using HomeServicesApp.Data;
using HomeServicesApp.Models;
using HomeServicesApp.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

[Authorize(Roles = "Worker")]
public class WorkerController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public WorkerController(AppDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // =========================
    // DASHBOARD
    // =========================
    public async Task<IActionResult> Dashboard()
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
            return RedirectToAction("Login", "Account");

        var worker = await _context.Workers
            .FirstOrDefaultAsync(w => w.UserId == user.Id);

        if (worker == null)
            return RedirectToAction("Logout", "Account");

        if (!worker.IsApproved)
            return View("WaitingApproval");

        return View(worker);
    }

    // =========================
    // ACTIVE JOBS
    // =========================
    public async Task<IActionResult> Activejob()
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
            return RedirectToAction("Login", "Account");

        var worker = await _context.Workers
            .FirstOrDefaultAsync(w => w.UserId == user.Id);

        if (worker == null)
            return RedirectToAction("Logout", "Account");

        var activeJobs = await _context.Bookings
            .Where(b => b.WorkerId == worker.WorkerId
                     && b.Status == BookingStatus.Pending)
            .ToListAsync();

        return View(activeJobs);
    }
    public IActionResult WaitingApproval()
    {
        return View();
    }
}