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
    public class LedgerController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;
        private readonly ILogger<AccountController> _logger;

        public LedgerController(IAppUnitOfWork uow, ILogger<AccountController> logger)
        {
            _uow = uow;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ledger>>> GetLedgers()
        {
            return Ok(await _uow.Ledger.AllAsync());
        }
    }
}