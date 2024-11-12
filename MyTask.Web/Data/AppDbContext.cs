using Microsoft.EntityFrameworkCore;
using MyTask.Web.Models.Domain;

namespace MyTask.Web.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options) 
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
