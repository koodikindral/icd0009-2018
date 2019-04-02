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
    public class CurrencyController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;
        private readonly ILogger<CurrencyController> _logger;

        public CurrencyController(IAppUnitOfWork uow, ILogger<CurrencyController> logger)
        {
            _uow = uow;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Currency>>> GetCurrencies()
        {
            return Ok(await _uow.Currencies.AllAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Currency>> GetCurrency(int id)
        {
            var currency = await _uow.Currencies.FindAsync(id);
            
            if (currency == null)
            {
                return NotFound();
            }
            return currency;
        }
        
        [HttpPost]
        public async Task<ActionResult<Currency>> PostCurrency(Currency currency)
        {
            await _uow.Currencies.AddAsync(currency);
            await _uow.SaveChangesAsync();
            _logger.LogInformation("Currency added: {ID}", currency.Id);
            return CreatedAtAction("GetCurrency", new { id = currency.Id }, currency);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrency(int id, Currency currency)
        {
            if (id != currency.Id)
            {
                return BadRequest();
            }

            _uow.Currencies.Update(currency);
            await _uow.SaveChangesAsync();
            _logger.LogInformation("Currency updated: {ID}", currency.Id);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Currency>> DeleteCurrency(int id)
        {
            var currency = await _uow.Currencies.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }

            _uow.Currencies.Remove(currency);
            await _uow.SaveChangesAsync();
            _logger.LogInformation("Currency deleted: {ID}", currency.Id);
            return currency;
        }
    }
}