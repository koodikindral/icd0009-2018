using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        // GET: api/Users
        [HttpGet]
        public ActionResult<UserModel> Index()
        {
            return new UserModel(1, "Gert");
        }
    }
}