using DebtNote.Models;
using Microsoft.EntityFrameworkCore;

namespace DebtNote.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Payment>? Payments { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) => Database.EnsureCreated();
    }
}