using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Sportsbook.UnitOfWork.Interface;
using Domain.Sportsbook;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SportsbookApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OddsController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;
        private readonly ILogger<OddsController> _logger;

        public OddsController(IAppUnitOfWork uow, ILogger<OddsController> logger)
        {
            _uow = uow;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Odds>>> GetOdds()
        {
            return Ok(await _uow.Odds.AllAsync());
        }
    }
}