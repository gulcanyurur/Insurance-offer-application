using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Eureko.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public IActionResult PostPayment(Payment payment)
        {
            try
            {
                _paymentService.Add(payment);
                return Ok(new { Message = "Ödemeniz alınmıştır.", Data = payment });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "";
                return StatusCode(500, new { Message = $"{ex.Message} {innerException}" });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPayment(int id)
        {
            var payment = _paymentService.Get(p => p.PaymentID == id);
            if (payment == null)
            {
                return NotFound("Ödeme bulunamadı.");
            }
            return Ok(new { Message = "Ödeme getirildi.", Data = payment });
        }

        [HttpGet]
        public IActionResult GetPayments()
        {
            var payments = _paymentService.GetList();
            return Ok(new { Message = "Ödemeler listelendi.", Data = payments });
        }
    }
}

