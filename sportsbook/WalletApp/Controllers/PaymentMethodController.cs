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
    public class PaymentMethodController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;
        private readonly ILogger<PaymentMethodController> _logger;

        public PaymentMethodController(IAppUnitOfWork uow, ILogger<PaymentMethodController> logger)
        {
            _uow = uow;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentMethod>>> GetPaymentMethods()
        {
            return Ok(await _uow.PaymentMethods.AllAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentMethod>> GetPaymentMethod(int id)
        {
            var paymentMethod = await _uow.PaymentMethods.FindAsync(id);
            
            if (paymentMethod == null)
            {
                return NotFound();
            }
            return paymentMethod;
        }
        
        [HttpPost]
        public async Task<ActionResult<PaymentMethod>> PostPaymentMethod(PaymentMethod paymentMethod)
        {
            await _uow.PaymentMethods.AddAsync(paymentMethod);
            await _uow.SaveChangesAsync();
            _logger.LogInformation("Payment method created: {ID}", paymentMethod.Id);
            return CreatedAtAction("GetPaymentMethod", new { id = paymentMethod.Id }, paymentMethod);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentMethod(int id, PaymentMethod paymentMethod)
        {
            if (id != paymentMethod.Id)
            {
                return BadRequest();
            }

            _uow.PaymentMethods.Update(paymentMethod);
            await _uow.SaveChangesAsync();
            _logger.LogInformation("Payment method updated: {ID}", paymentMethod.Id);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentMethod>> DeletePaymentMethod(int id)
        {
            var paymentMethod = await _uow.PaymentMethods.FindAsync(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            _uow.PaymentMethods.Remove(paymentMethod);
            await _uow.SaveChangesAsync();
            _logger.LogInformation("Payment method deleted: {ID}", paymentMethod.Id);
            return paymentMethod;
        }
    }
}