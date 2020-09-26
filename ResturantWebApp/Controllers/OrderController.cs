using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ResturantWebApp.Dtos;
using ResturantWebApp.Models;
using ResturantWebApp.Repo;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace ResturantWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _ctx;
        private readonly IMapper _mapper;
        public OrderController(AppDbContext ctx, IMapper mapper)
        {
            this._ctx = ctx;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("addOrder")]
        public async Task<ActionResult> AddOrderAsync(OrderEditDto order)
        {
            var orderBaseInfo = this._mapper.Map<OrderEntity>(order);
            var orderItems = this._mapper.Map<IEnumerable<OrderItemEntity>>(order.OrderItems);

            using (var transaction = this._ctx.Database.BeginTransaction())
            {
                try
                {
                    await this._ctx.Orders.AddAsync(orderBaseInfo);
                    orderBaseInfo.Transaction = transaction.TransactionId.ToString();
                    await this._ctx.SaveChangesAsync();
                    foreach (var item in orderItems)
                    {
                        item.OrderID = orderBaseInfo.ID;
                        item.Transaction = transaction.TransactionId.ToString();
                    }
                    await this._ctx.OrderItems.AddRangeAsync(orderItems);
                    await this._ctx.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    await transaction.RollbackAsync();
                }
            }

            return Ok();
        }

        [HttpPost]
        [Route("updateOrder")]
        public async Task<ActionResult> UpdateOrderAsync(OrderEditDto order)
        {
            var oriOrder = await this._ctx.Orders.FindAsync(order.OrderID);
            if (oriOrder == null)
            {
                return NotFound();
            }
            using (var transaction = this._ctx.Database.BeginTransaction())
            {
                try
                {
                    this._mapper.Map(order, oriOrder);

                    // remove exclude
                    var orderItemIds = order.OrderItems.Select(p => p.OrderItemID);
                    var removeOrderItems = this._ctx.OrderItems.Where(p => p.OrderID == oriOrder.ID && orderItemIds.Contains(p.ID));
                    this._ctx.OrderItems.RemoveRange(removeOrderItems);

                    // new add
                    var newOrderItems = order.OrderItems.Where(p => p.OrderItemID == 0);
                    var dbOrderItems = this._mapper.Map<OrderItemEntity>(newOrderItems);
                    await this._ctx.OrderItems.AddRangeAsync(dbOrderItems);
                    // update
                    var needUpdateOrderItems = order.OrderItems.Except(newOrderItems);
                    foreach (var item in needUpdateOrderItems)
                    {
                        var tmp = await this._ctx.OrderItems.FindAsync(item.OrderItemID);
                        this._mapper.Map(item, tmp);
                    }
                    await this._ctx.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Ok();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    await transaction.RollbackAsync();
                    return BadRequest(new { Err = ex.Message });
                }
            }
        }

        [HttpGet]
        [Route("orders")]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> FetchAllOrdersAsync()
        {
            var datas = await (from o in this._ctx.Orders
                                   //join i in this._ctx.OrderItems on o.ID equals i.OrderID
                               join c in this._ctx.Customers on o.CustomerID equals c.ID
                               join p in this._ctx.Payments on o.PaymentID equals p.ID
                               select new OrderReadDto
                               {
                                   OrderID = o.ID,
                                   OrderNum = o.OrderNumber,
                                   Customer = c.CustomerName,
                                   PMethod = p.PayMethod,
                                   Total = o.Total
                               }
                        ).Distinct().ToListAsync();
            return Ok(datas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrderDetailById(int id)
        {
            var orderDetail = await this._ctx.Orders.FindAsync(id);
            var orderItems = await (
                 from oi in this._ctx.OrderItems
                 join i in this._ctx.Items on oi.ItemID equals i.ID
                 where oi.OrderID == id
                 select new
                 {
                     OrderItemID = oi.ID,
                     OrderID = id,
                     ItemID = i.ID,
                     Quantity = oi.Quantity,
                     ItemName = i.ItemName,
                     Price = i.Price,
                     Total = i.Price * oi.Quantity
                 }
            ).Distinct().ToListAsync();

            return Ok(new
            {
                OrderInfo = this._mapper.Map<OrderDetailReadDto>(orderDetail),
                OrderItems = orderItems
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            using (var transaction = this._ctx.Database.BeginTransaction())
            {
                try
                {
                    var orderItems = this._ctx.OrderItems.Where(p => p.OrderID == id);
                    this._ctx.OrderItems.RemoveRange(orderItems);

                    var orders = this._ctx.Orders.Where(p => p.ID == id);
                    this._ctx.Orders.RemoveRange(orders);
                    await this._ctx.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return Ok();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    await transaction.RollbackAsync();
                    return BadRequest(new { Err = ex.Message });
                }
            }
        }
    }
}