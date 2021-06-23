using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quizzler.Contexts;
using Quizzler.Logic;
using Quizzler.Models;

namespace Quizzler.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserDbContext _context;

        public UserController(UserDbContext context)
        {
            _context = context;
        }

        //Create
        [HttpPost]
        public async Task<IActionResult> CreateUser(string username, string password, string confPassword, string emailAddress)
        {

            try
            {

                User newUser = new User()
                {
                    UserName = username,
                    Password = password,
                    Email = emailAddress
                };

                var validInput = EnsureValidInput.EnsureUserData(newUser, confPassword);

                if (validInput)
                {
                    await _context.AddAsync(newUser);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest("Invalid User Data.");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok();
        }

        //Read

        //Update

        //Delete
    }
}
