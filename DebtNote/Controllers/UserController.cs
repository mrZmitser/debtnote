﻿using Microsoft.AspNetCore.Http;
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
        public JsonResult GetById(int id)
        {
            return new JsonResult(UserService.GetById(id));//do smth for 404
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public JsonResult CreateUser(User user) => new JsonResult(UserService.CreateUser(user));
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public JsonResult UpdateUser(User user) => new JsonResult(UserService.UpdateUser(user)); //TODO: fix error 500
        //public async Task<IActionResult> UpdateUser(int id, User user)
        //{
        //    if(id!= user.Id) return BadRequest();
        //    _context.Entry(user).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public JsonResult DeleteUser(int id) => new JsonResult(DeleteUser(id)); // TODO: fix acces vioalation
        //public async Task<IActionResult> DeleteUser(int id)
        //{
        //    var userToDelete = await _context.Users.FindAsync(id);
        //    if(userToDelete == null) return NotFound();
        //    _context.Users.Remove(userToDelete);
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}

    }
}
