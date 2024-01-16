using ccse_cw1.Models;
using ccse_cw1.Services;
using Microsoft.AspNetCore.Mvc;

namespace ccse_cw1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }
    }
}
