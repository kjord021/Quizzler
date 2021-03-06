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

        [HttpGet("{username}/username/{password}/password")]
        public async Task<IActionResult> AttemptLogin(string username, string password) 
        {
            try
            {
                var user = await UserRepositoryFunctions.GetUserByUserName(username, _context);

                if (user != null)
                {
                    if (password == user.Password)
                    {
                        return Ok(UserConstants.SuccessMessage);
                    }
                    else 
                    {
                        return BadRequest("Incorrect Password");
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok("The User Does Not Exist");
        }

        [HttpPut("{username}/updateUserName")]
        public async Task<IActionResult> UpdateUserByUsername(string username, string newUserName, string password, string confPassword, string emailAddress)
        {
            try
            {
                var user = await UserRepositoryFunctions.GetUserByUserName(username, _context);

                if (user != null)
                {
                    var returnString = EnsureValidInput.EnsureUserDataOnUpdate(user, confPassword);

                    if (returnString == UserConstants.Ok)
                    {
                        var newUserData = new User()
                        {
                            Id = user.Id,
                            UserName = newUserName,
                            Password = password,
                            Email = emailAddress
                        };

                        await UserRepositoryFunctions.UpdateUser(newUserData, _context);

                        return Ok("User Successfully Updated");
                    }
                    else 
                    {
                        return Ok(returnString);
                    }
                }
                else 
                {
                    return Ok("The User Does Not Exist");
                }

            }
            catch (Exception e) 
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{id}/updateId")]
        public async Task<IActionResult> UpdateUserById(int id, string username, string password, string confPassword, string emailAddress)
        {
            try
            {
                var user = await UserRepositoryFunctions.GetUserById(id, _context);

                if (user != null)
                {
                    var returnString = EnsureValidInput.EnsureUserDataOnUpdate(user, confPassword);

                    if (returnString == UserConstants.Ok)
                    {
                        var newUserData = new User()
                        {
                            Id = user.Id,
                            UserName = username,
                            Password = password,
                            Email = emailAddress
                        };

                        await UserRepositoryFunctions.UpdateUser(newUserData, _context);

                        return Ok("User Successfully Updated");
                    }
                    else
                    {
                        return Ok(returnString);
                    }
                }
                else
                {
                    return Ok("The User Does Not Exist");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            try
            {
                var user = await UserRepositoryFunctions.GetUserById(id, _context);
                await UserRepositoryFunctions.DeleteUser(user, _context);
            }
            catch (Exception e) 
            {
                return BadRequest(e);
            }

            return Ok("User Sucessfully Deleted");
        }

    }
}
