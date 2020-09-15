using System.Collections.Generic;
using System.Threading.Tasks;
using AngularForDotnetCore.Components;
using AngularForDotnetCore.Models;
using AngularForDotnetCore.Repo;
using Microsoft.AspNetCore.Mvc;

namespace AngularForDotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private BankComponent bc;
        public BankController(BankComponent bc)
        {
            this.bc = bc;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bank>>> GetBank()
        {
            var banks = await this.bc.GetBanksAsync();
            return Ok(banks);
        }
    }
}