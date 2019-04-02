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
    public class AccountController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAppUnitOfWork uow, ILogger<AccountController> logger)
        {
            _uow = uow;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            return Ok(await _uow.Accounts.AllAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await _uow.Accounts.FindAsync(id);
            
            if (account == null)
            {
                return NotFound();
            }
            return account;
        }
        
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account account)
        {
            await _uow.Accounts.AddAsync(account);
            await _uow.SaveChangesAsync();
            _logger.LogInformation("Account created: {ID}, user-id: {USER}", account.Id, account.UserId);
            return CreatedAtAction("GetAccount", new { id = account.Id }, account);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, Account account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            _uow.Accounts.Update(account);
            await _uow.SaveChangesAsync();
            _logger.LogInformation("Account updated: {ID}", account.Id);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Account>> DeleteAccount(int id)
        {
            var account = await _uow.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _uow.Accounts.Remove(account);
            await _uow.SaveChangesAsync();
            _logger.LogInformation("Account deleted: {ID}", account.Id);
            return account;
        }
    }
}