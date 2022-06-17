using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DebtNote.Database;
using DebtNote.Models;
using Microsoft.EntityFrameworkCore;

namespace DebtNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UserController(ApplicationContext context) => _context = context;
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers() => await _context.Users.ToListAsync();
        [HttpGet("id")]
        [ProducesResponseType(typeof(User),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById (int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user  == null ? NotFound() : Ok(user); 
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById),new {id= user.Id}, user);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if(id!= user.Id) return BadRequest();
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userToDelete = await _context.Users.FindAsync(id);
            if(userToDelete == null) return NotFound();
            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
