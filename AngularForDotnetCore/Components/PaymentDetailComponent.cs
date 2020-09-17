
using System.Collections.Generic;
using System.Threading.Tasks;
using AngularForDotnetCore.Models;
using AngularForDotnetCore.Repo;
using Microsoft.EntityFrameworkCore;

namespace AngularForDotnetCore.Components
{
    public class PaymentDetailComponent
    {
        private readonly ApiDbContext _ctx;
        public PaymentDetailComponent(ApiDbContext ctx)
        {
            this._ctx = ctx;
        }

        public async Task<IEnumerable<PaymentDetail>> GetPaymentDetails()
        {
            return await this._ctx.PaymentDetails.ToListAsync();
        }

        public async Task<PaymentDetail> GetPaymentDetailById(int id)
        {
            return await this._ctx.PaymentDetails.FindAsync(id);
        }

        public async Task AddPaymentDetail(PaymentDetail payment)
        {
            await this._ctx.PaymentDetails.AddAsync(payment);
            await this._ctx.SaveChangesAsync();
        }

        public async Task UpdatePaymentDetail(PaymentDetail paymentDetail)
        {
            await this._ctx.SaveChangesAsync();
        }

        public async Task DeletePaymentDetail(int id)
        {
            var payment = await this._ctx.PaymentDetails.FindAsync(id);
            if(null != payment)
            {
                this._ctx.PaymentDetails.Remove(payment);
            }
            await this._ctx.SaveChangesAsync();
        }
    }
}