using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    ///general structure for a controller that has a database table in this case "users"
    //follow the same structure to add more controllers
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task < ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await  _context.Users.ToListAsync();

        }

        //api/users/id
        [HttpGet("{id}")]
        public async Task < ActionResult<AppUser>> GetUser(int id)
        {
            ////find id from the database            
            return await _context.Users.FindAsync(id);

        }

    }


}