using AngularForDotnetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularForDotnetCore.Repo
{
    public class ApiDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=angularForDotnetCore.db");
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
    }

}