using Microsoft.EntityFrameworkCore;
using TaskApplicationWithCQRS.Domain;

namespace TaskApplicationWithCQRS.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
