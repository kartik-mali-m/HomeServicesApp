using HomeServicesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeServicesApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Booking Relationships
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Worker)
                .WithMany(w => w.Bookings)
                .HasForeignKey(b => b.WorkerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Service)
                .WithMany(s => s.Bookings)
                .HasForeignKey(b => b.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // ✅ ADD INDEX HERE (Inside OnModelCreating)
            modelBuilder.Entity<Booking>()
                .HasIndex(b => b.BookingDate);
        }
    }
}