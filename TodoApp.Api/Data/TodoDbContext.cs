using Microsoft.EntityFrameworkCore;
using TodoApp.Api.Models.Domain;

namespace TodoApp.Api.Data
{
    public class TodoDbContext : DbContext
    {

        public TodoDbContext(DbContextOptions<TodoDbContext> dbContext) : base(dbContext)
        {
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
