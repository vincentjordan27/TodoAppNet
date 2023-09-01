using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.Api.Data
{
    public class TodoAuthDbContext : IdentityDbContext
    {
        public TodoAuthDbContext(DbContextOptions<TodoAuthDbContext> context) : base(context) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
