using Microsoft.EntityFrameworkCore;

namespace TodoApp.API.Data
{
    public class TodoDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TodoDb");
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Todo> Todo { get; set; }
    }
}
