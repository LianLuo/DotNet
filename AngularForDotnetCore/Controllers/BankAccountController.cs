using System.Collections.Generic;
using System.Threading.Tasks;
using AngularForDotnetCore.Components;
using AngularForDotnetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularForDotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private BankAccountComponent _bac;
        public BankAccountController(BankAccountComponent bac)
        {
            this._bac = bac;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankAccount>>> GetBankAccount()
        {
            var bankAccounts = await this._bac.GetBankAccountsAsync();
            return Ok(bankAccounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccount>> GetBankAccount(int id)
        {
            var bankAccount = await this._bac.GetBankByIdAsync(id);
            if(null == bankAccount)
            {
                return NotFound();
            }
            return bankAccount;
        }

        [HttpPost]
        public async Task<ActionResult<BankAccount>> CreateBankAccount(BankAccount bankAccount)
        {
            await this._bac.AddBankAsync(bankAccount);
            return Ok(bankAccount);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BankAccount>> UpdateBankAccount(int id, BankAccount bankAccount)
        {
            var bankAccountReal = await this._bac.GetBankByIdAsync(id);
            if(null != bankAccountReal && id == bankAccount.BankAccountID)
            {
                bankAccountReal.AccountHolder = bankAccount.AccountHolder;
                bankAccountReal.AccountNumber = bankAccount.AccountNumber;
                bankAccountReal.BankID = bankAccount.BankID;
                bankAccountReal.Remark = bankAccount.Remark;
            }
            await this._bac.UpdateBankAsync(bankAccountReal);
            return Ok(bankAccount);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BankAccount>> DeleteBankAccount(int id)
        {
            var bankAccount = await this._bac.GetBankByIdAsync(id);
            if(null == bankAccount)
            {
                return NotFound();
            }
            await this._bac.DeleteBankAsync(id);
            return Ok(bankAccount);
        }
    }
}