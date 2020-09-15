using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularForDotnetCore.Models;
using AngularForDotnetCore.Repo;
using Microsoft.EntityFrameworkCore;

namespace AngularForDotnetCore.Components
{
    public class BankComponent
    {
        private ApiDbContext _ctx;

        public BankComponent(ApiDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AddBankAsync(Bank bank)
        {
            this._ctx.Banks.Add(bank);
            await this._ctx.SaveChangesAsync();
        }

        public void AddBank(Bank bank)
        {
            this._ctx.Banks.Add(bank);
            this._ctx.SaveChanges();
        }

        public async Task DeleteBankAsync(int bankId)
        {
            var bank = await this._ctx.Banks.FindAsync(bankId);
            if(bank != null)
            {
                this._ctx.Banks.Remove(bank);
            }
            await this._ctx.SaveChangesAsync();
        }

        public void DeleteBank(int bankId)
        {
            var bank = this._ctx.Banks.Find(bankId);
            if(bank != null)
            {
                this._ctx.Banks.Remove(bank);
            }
            this._ctx.SaveChanges();
        }

        public async Task UpdateBankAsync(Bank bank)
        {
            await this._ctx.SaveChangesAsync();
        }

        public void UpdateBank(Bank bank)
        {
            this._ctx.SaveChanges();
        }

        public async Task<Bank> GetBankByIdAsync(int bankId)
        {
            var bank = await this._ctx.Banks.FindAsync(bankId);
            return bank;
        }

        // public Bank GetBankById(int bankId)
        // {
        //     return this._ctx.Banks.Where(f=>f.BankID == bankId).FirstOrDefault();
        // }


        public IEnumerable<Bank> GetBanks()
        {
            return this._ctx.Banks.ToList();
        }

        public async Task<IEnumerable<Bank>> GetBanksAsync()
        {
            return await this._ctx.Banks.ToListAsync();
        }
    }
}