using HomeServicesApp.Data;
using HomeServicesApp.Enum;
using HomeServicesApp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class WorkerController : Controller
{
    private readonly AppDbContext _context;

    public WorkerController(AppDbContext context)
    {
        _context = context;
    }

    [Authorize(Roles = "Worker")]
    public async Task<IActionResult> Dashboard(int workerId)
    {
        var worker = await _context.Workers
            .FirstOrDefaultAsync(w => w.WorkerId == workerId);

        if (worker == null)
            return NotFound();

        var bookings = await _context.Bookings
            .Where(b => b.WorkerId == workerId)
            .Include(b => b.Service)
            .ToListAsync();

        var viewModel = new WorkerDashboardViewModel
        {
            WorkerName = worker.Name,
            TotalBookings = bookings.Count,
            PendingBookings = bookings.Count(b => b.Status == BookingStatus.Pending),
            CompletedBookings = bookings.Count(b => b.Status == BookingStatus.Completed),
            TotalEarnings = bookings
                .Where(b => b.Status == BookingStatus.Completed)
                .Sum(b => b.Service.Price),

            RecentBookings = bookings.OrderByDescending(b => b.BookingDate).Take(5).ToList()
        };

        return View(viewModel);
      
    }

    public IActionResult Activejob()
    {
        return View();
    
    }
}