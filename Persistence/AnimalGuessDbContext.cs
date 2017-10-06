using System;
using Microsoft.EntityFrameworkCore;

namespace AnimalGuess.Persistence
{
    public class AnimalGuessDbContext : DbContext
	{
		public DbSet<Animal> Animals { get; set; }
		public DbSet<Hint> Hints { get; set; }

		public AnimalGuessDbContext(DbContextOptions<AnimalGuessDbContext> options) : base(options)
        {   
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=AnimalGuess.db");
        }
    }
}
