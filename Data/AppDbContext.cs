using KanbanAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KanbanAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Board> Boards => Set<Board>();
        public DbSet<Card> Cards => Set<Card>();
    }
}