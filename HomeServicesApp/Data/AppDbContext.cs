using HomeServicesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeServicesApp.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Service> Services { get; set; }
        public DbSet<Problem> Problems { get; set; }
    }
}
