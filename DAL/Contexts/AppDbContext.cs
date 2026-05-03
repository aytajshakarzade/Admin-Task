using Admin_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace Admin_Task.DAL.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Projects> Projects { get; set; }
    }
}