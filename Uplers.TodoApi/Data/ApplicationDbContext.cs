using Microsoft.EntityFrameworkCore;
using Uplers.TodoApi.Model;

namespace Uplers.TodoApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Todo> todosList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().ToTable("todosList");
            
        }
    }
}
