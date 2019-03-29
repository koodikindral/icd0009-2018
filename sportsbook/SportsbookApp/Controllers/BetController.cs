using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Sportsbook.UnitOfWork;
using DAL.Sportsbook.UnitOfWork.Interface;
using Domain.Sportsbook;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SportsbookApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;
        private readonly ILogger<BetController> _logger;

        public BetController(IAppUnitOfWork uow, ILogger<BetController> logger)
        {
            _uow = uow;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bet>>> GetBets()
        {
            return Ok(await _uow.Bets.AllAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Bet>> GetBet(int id)
        {
            var bet = await _uow.Bets.FindAsync(id);
            
            if (bet == null)
            {
                return NotFound();
            }
            return bet;
        }
        
        [HttpPost]
        public async Task<ActionResult<Bet>> PostBet(Bet bet)
        {
            // TODO: get user id from jwt context
            await _uow.Bets.AddAsync(bet);
            await _uow.SaveChangesAsync();
            _logger.LogInformation("Bet placed: {ID}, user-id: {USER}", bet.Id, bet.UserId);
            return CreatedAtAction("GetBet", new { id = bet.Id }, bet);
        }
    }
}