using Microsoft.EntityFrameworkCore;
using RdManipulation.Domain.Entities;

namespace RdManipulation.Infra.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Video>().HasKey(v => v.Id);
        }
    }
}
