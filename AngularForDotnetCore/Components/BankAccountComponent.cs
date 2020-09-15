using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularForDotnetCore.Models;
using AngularForDotnetCore.Repo;
using Microsoft.EntityFrameworkCore;

namespace AngularForDotnetCore.Components
{
    public class BankAccountComponent
    {
        private ApiDbContext _ctx;

        public BankAccountComponent(ApiDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AddBankAsync(BankAccount bank)
        {
            this._ctx.BankAccounts.Add(bank);
            await this._ctx.SaveChangesAsync();
        }

        public void AddBank(BankAccount bank)
        {
            this._ctx.BankAccounts.Add(bank);
            this._ctx.SaveChanges();
        }

        public async Task DeleteBankAsync(int bankId)
        {
            var bank = await this._ctx.BankAccounts.FindAsync(bankId);
            if(bank != null)
            {
                this._ctx.BankAccounts.Remove(bank);
            }
            await this._ctx.SaveChangesAsync();
        }

        public void DeleteBank(int bankId)
        {
            var bank = this._ctx.BankAccounts.Find(bankId);
            if(bank != null)
            {
                this._ctx.BankAccounts.Remove(bank);
            }
            this._ctx.SaveChanges();
        }

        public async Task UpdateBankAsync(BankAccount bank)
        {
            await this._ctx.SaveChangesAsync();
        }

        public void UpdateBank(BankAccount bank)
        {
            this._ctx.SaveChanges();
        }

        public async Task<BankAccount> GetBankByIdAsync(int bankId)
        {
            var bank = await this._ctx.BankAccounts.FindAsync(bankId);
            return bank;
        }

        public BankAccount GetBankById(int bankId)
        {
            return this._ctx.BankAccounts.Where(f=>f.BankID == bankId).FirstOrDefault();
        }


        public IEnumerable<BankAccount> GetBankAccounts()
        {
            return this._ctx.BankAccounts.ToList();
        }

        public async Task<IEnumerable<BankAccount>> GetBankAccountsAsync()
        {
            return await this._ctx.BankAccounts.ToListAsync();
        }
    }
}