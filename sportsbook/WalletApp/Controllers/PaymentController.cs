using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Wallet.UnitOfWork.Interface;
using Domain.Wallet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WalletApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(IAppUnitOfWork uow, ILogger<PaymentController> logger)
        {
            _uow = uow;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            return Ok(await _uow.Payments.AllAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            var payment = await _uow.Payments.FindAsync(id);
            
            if (payment == null)
            {
                return NotFound();
            }
            return payment;
        }
        
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            await _uow.Payments.AddAsync(payment);
            await _uow.SaveChangesAsync();
            _logger.LogInformation("Payment created: {ID}, user-id: {USER}", payment.Id, payment.UserId);
            return CreatedAtAction("GetPayment", new { id = payment.Id }, payment);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, Payment payment)
        {
            if (id != payment.Id)
            {
                return BadRequest();
            }

            _uow.Payments.Update(payment);
            await _uow.SaveChangesAsync();
            _logger.LogInformation("Payment updated: {ID}", payment.Id);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Payment>> DeletePayment(int id)
        {
            var payment = await _uow.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            _uow.Payments.Remove(payment);
            await _uow.SaveChangesAsync();
            _logger.LogInformation("Payment deleted: {ID}", payment.Id);
            return payment;
        }
    }
}