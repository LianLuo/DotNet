using AngularForDotnetCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularForDotnetCore.Repo
{
    public class ApplicationUserContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Application.db");
        }

        public DbSet<ApplicationUserModel> ApplicationUserModels { get; set; }
    }
}
