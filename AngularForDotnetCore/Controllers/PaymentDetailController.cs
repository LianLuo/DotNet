using System.Collections.Generic;
using System.Threading.Tasks;
using AngularForDotnetCore.Components;
using AngularForDotnetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularForDotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly PaymentDetailComponent _payment;
        public PaymentDetailController(PaymentDetailComponent payment)
        {
            this._payment = payment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetails()
        {
            var payments = await this._payment.GetPaymentDetails();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int id)
        {
            var payment = await this._payment.GetPaymentDetailById(id);
            return Ok(payment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PaymentDetail>> UpdatePaymentDetail(int id, PaymentDetail payment)
        {
            var paymentDetail = await this._payment.GetPaymentDetailById(id);
            if(null != paymentDetail)
            {
                paymentDetail.CardNumber = payment.CardNumber;
                paymentDetail.CardOwnerName = payment.CardNumber;
                paymentDetail.CVV = payment.CVV;
                paymentDetail.ExpiretionDate = payment.ExpiretionDate;
                await this._payment.UpdatePaymentDetail(paymentDetail);
            }
            return Ok(payment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentDetail>> DeletePaymentDetail(int id)
        {
            await this._payment.DeletePaymentDetail(id);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<PaymentDetail>> AddPaymentDetail(PaymentDetail paymentDetail)
        {
            await this._payment.AddPaymentDetail(paymentDetail);
            return Ok(paymentDetail);
        }

    }
}