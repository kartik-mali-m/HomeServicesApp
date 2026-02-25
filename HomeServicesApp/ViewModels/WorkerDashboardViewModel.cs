namespace HomeServicesApp.Models.ViewModels
{
    public class WorkerDashboardViewModel
    {
        public string WorkerName { get; set; } = string.Empty;

        public int TotalBookings { get; set; }
        public int PendingBookings { get; set; }
        public int CompletedBookings { get; set; }

        public decimal TotalEarnings { get; set; }

        public List<Booking> RecentBookings { get; set; } = new List<Booking>();
    }
}