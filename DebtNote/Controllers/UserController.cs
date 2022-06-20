using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DebtNote.Database;
using DebtNote.Models;
using Microsoft.EntityFrameworkCore;
using DebtNote.Services.Interfaces;

namespace DebtNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private IUserService UserService { get; set; }

        public UserController(ApplicationContext context, IUserService userService) 
        {
            _context = context;
            UserService = userService;
        }

        [HttpGet]
        public JsonResult GetUsers() => new JsonResult(UserService.GetAll());

        [HttpGet("id")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var result = UserService.GetById(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateUser(User user)
        {
            UserService.CreateUser(user);
            return CreatedAtAction(nameof(GetById),new {id=user.Id},user);
        } 
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateUser(int id, User user)
        {
            if (id != user.Id) return BadRequest();
            UserService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userToDelete = await _context.Users.FindAsync(id);
            if (userToDelete == null) return NotFound();
            await UserService.DeleteUserAsync(id);
            return NoContent();
        }

    }
}
