using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GameCatalog.DAL
{
    public class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Studio> Studios { get; set; }

        public GameContext(DbContextOptions<GameContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=GameCatalogDB;Trusted_Connection=True;");
            }
        }
    }
}
