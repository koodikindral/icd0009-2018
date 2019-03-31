using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Wallet.UnitOfWork.Interface;
using Domain.Wallet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WalletApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IAppUnitOfWork uow, ILogger<ProductController> logger)
        {
            _uow = uow;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await _uow.Products.AllAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _uow.Products.FindAsync(id);
            
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }
        
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            await _uow.Products.AddAsync(product);
            await _uow.SaveChangesAsync();
            _logger.LogInformation("Product created: {ID},", product.Id);
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _uow.Products.Update(product);
            await _uow.SaveChangesAsync();
            _logger.LogInformation("Product updated: {ID}", product.Id);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _uow.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _uow.Products.Remove(product);
            await _uow.SaveChangesAsync();
            _logger.LogInformation("Product deleted: {ID}", product.Id);
            return product;
        }
    }
}