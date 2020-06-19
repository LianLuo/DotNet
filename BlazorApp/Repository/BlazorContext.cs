using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Repository
{
    public class BlazorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=BlazorDb.db");
        }

        public DbSet<Commander> Commanders{get;set;}
        public DbSet<ExampleModel> ExampleModels {get;set;}
        public DbSet<Starship> Starships {get;set;}
    }
}