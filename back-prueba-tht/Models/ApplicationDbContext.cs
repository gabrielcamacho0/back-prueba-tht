using Microsoft.EntityFrameworkCore;

namespace back_prueba_tht.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base (options)
        {
            
        }

        public DbSet<Task> task { get; set; }
        public DbSet<TaskStatus> taskStatus { get; set; }
    }
}
