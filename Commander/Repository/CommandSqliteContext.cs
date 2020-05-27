using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Repository
{
    public class CommandSqliteContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=CommandDb.db");
        }

        public DbSet<Command> Commands {get;set;}
    }
}