using Microsoft.EntityFrameworkCore;
using todolist_api.Entities;

namespace todolist_api.Context
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> context) : base(context)
        {
        }

        public DbSet<Todos> Todos { get; set; }
    }
}
