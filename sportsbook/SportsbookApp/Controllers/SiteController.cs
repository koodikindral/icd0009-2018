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
    public class SiteController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;
        private readonly ILogger<SiteController> _logger;

        public SiteController(IAppUnitOfWork uow, ILogger<SiteController> logger)
        {
            _uow = uow;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Site>>> GetSites()
        {
            return Ok(await _uow.Sites.AllAsync());
        }
    }
}