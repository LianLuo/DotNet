using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ResturantWebApp.Repo;
using System.Threading.Tasks;
using System.Collections.Generic;
using ResturantWebApp.Dtos;
using ResturantWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ResturantWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly AppDbContext _ctx;
        private readonly IMapper _mapper;

        public CommonController(AppDbContext ctx, IMapper mapper)
        {
            this._ctx = ctx;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("customers")]
        public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetCustomersAsync()
        {
            var customers = await this._ctx.Customers.ToListAsync();
            return Ok(this._mapper.Map<IEnumerable<CustomerReadDto>>(customers));
        }

        [HttpPost]
        [Route("customers")]
        public async Task<ActionResult<CustomerReadDto>> AddCustomerAsync(IEnumerable<CustomerEditDto> customerEdits)
        {
            var cusotmers = this._mapper.Map<IEnumerable<CustomerEntity>>(customerEdits);
            await this._ctx.Customers.AddRangeAsync(cusotmers);
            await this._ctx.SaveChangesAsync();
            return Ok(this._mapper.Map<IEnumerable<CustomerReadDto>>(cusotmers));
        }

        [HttpGet]
        [Route("items")]
        public async Task<ActionResult<IEnumerable<ItemReadDto>>> GetItemsAsync()
        {
            var items = await this._ctx.Items.ToListAsync();

            return Ok(this._mapper.Map<IEnumerable<ItemReadDto>>(items));
        }

        [HttpPost]
        [Route("items")]
        public async Task<ActionResult<IEnumerable<ItemReadDto>>> AddItemsAsync(IEnumerable<ItemEditDto> items)
        {
            var convertItems = this._mapper.Map<IEnumerable<ItemEntity>>(items);
            await this._ctx.Items.AddRangeAsync(convertItems);
            await this._ctx.SaveChangesAsync();
            return Ok(this._mapper.Map<IEnumerable<ItemReadDto>>(convertItems));
        }

        [HttpGet]
        [Route("payments")]
        public async Task<ActionResult<IEnumerable<object>>> GetPaymentsAsync()
        {
            var payments = await this._ctx.Payments.ToListAsync();

            return Ok(this._mapper.Map<IEnumerable<PaymentReadDto>>(payments));
        }

        [HttpPost]
        [Route("payments")]
        public async Task<ActionResult<IEnumerable<PaymentReadDto>>> AddPaymentsAsync(IEnumerable<PaymentEditDto> payments)
        {
            var convertPays = this._mapper.Map<IEnumerable<PaymentEntity>>(payments);
            await this._ctx.Payments.AddRangeAsync(convertPays);
            await this._ctx.SaveChangesAsync();
            return Ok(this._mapper.Map<IEnumerable<PaymentReadDto>>(convertPays));
        }
    }
}