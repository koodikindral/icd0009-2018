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
    public class CategoryController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(IAppUnitOfWork uow, ILogger<CategoryController> logger)
        {
            _uow = uow;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return Ok(await _uow.Categories.AllAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _uow.Categories.FindAsync(id);
            
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _uow.Categories.Update(category);
            await _uow.SaveChangesAsync();
            _logger.LogInformation("Category updated: {ID}", category.Id);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Bet>> PostGetCategory(Category category)
        {
            await _uow.Categories.AddAsync(category);
            await _uow.SaveChangesAsync();
            _logger.LogInformation("Category added: {ID}", category.Id);
            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var category = await _uow.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _uow.Categories.Remove(category);
            await _uow.SaveChangesAsync();
            _logger.LogInformation("Category deleted: {ID}", category.Id);
            return category;
        }
    }
}