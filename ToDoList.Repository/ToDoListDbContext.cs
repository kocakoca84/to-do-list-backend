using Microsoft.EntityFrameworkCore;
using ToDoList.Model;

namespace ToDoList.Repository
{
    public class ToDoListDbContext : DbContext
    {
        public ToDoListDbContext(
            DbContextOptions<ToDoListDbContext> dbContextOptions)
            : base(dbContextOptions) { }

        public DbSet<ToDoTask> ToDoTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoTask>()
                .HasKey(t => t.Id);
        }
    }
}
