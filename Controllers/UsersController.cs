using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BackendContext _context;

        public UsersController(BackendContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction("CreateUser", new { id = user.Id }, user);
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao criar o usuário!");
            }
        }
    }
}
