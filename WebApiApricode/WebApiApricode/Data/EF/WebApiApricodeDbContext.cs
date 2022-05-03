using Microsoft.EntityFrameworkCore;
using WebApiApricode.Data.Ef.Configurations;
using WebApiApricode.Data.Contracts.Models.Entities;

namespace WebApiApricode.Data.Ef
{
    internal class WebApiApricodeDbContext : DbContext
    {
        public DbSet<GameEntity> Games { get; set; }

        public WebApiApricodeDbContext(DbContextOptions<WebApiApricodeDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GamesRepositoryConfiguration());
        }
    }
}