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

                var returnString = EnsureValidInput.EnsureUserData(newUser, confPassword, _context);

                if (returnString == UserConstants.Ok)
                {
                    await UserRepositoryFunctions.CreateUser(newUser, _context);
                }
                else
                {
                    return BadRequest(returnString);
                }

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok();
        }

        [HttpGet("{username}/username")]
        public async Task<IActionResult> ReadUserByUserName(string username)
        {
            try 
            {
                var user = await UserRepositoryFunctions.GetUserByUserName(username, _context);

                if (user != null) 
                {
                    return Ok(user);
                }
            }
            catch (Exception e)
            {
                BadRequest(e);
            }

            return Ok("The User Does Not Exist");
        }

        [HttpGet("{id}/userId")]
        public async Task<IActionResult> ReadUserById(int id)
        {
            try
            {
                var user = await UserRepositoryFunctions.GetUserById(id, _context);

                if (user != null)
                {
                    return Ok(user);
                }
            }
            catch (Exception e)
            {
                BadRequest(e);
            }

            return Ok("The User Does Not Exist");
        }

        //Update

        //Delete
    }
}
