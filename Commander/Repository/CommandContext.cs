using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Repository
{
    public class CommandContext : DbContext
    {
        public CommandContext(DbContextOptions<CommandContext> opt): base(opt)
        {
            
        }

        public DbSet<Command> Commands{get;set;}
    }
}