using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly AppDbContext db;
   
        public UsersController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await db.Users.ToListAsync();
        }

        
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return CreatedAtAction("GetUsers", new { id = user.Id }, user);
        }

    }
}