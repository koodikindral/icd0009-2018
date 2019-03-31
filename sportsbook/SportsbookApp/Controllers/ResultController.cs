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
    public class ResultController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;
        private readonly ILogger<ResultController> _logger;

        public ResultController(IAppUnitOfWork uow, ILogger<ResultController> logger)
        {
            _uow = uow;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Result>>> GetResults()
        {
            return Ok(await _uow.Results.AllAsync());
        }
    }
}