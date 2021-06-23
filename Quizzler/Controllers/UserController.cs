using System;
using Microsoft.AspNetCore.Mvc;
using Quizzler.Contexts;

namespace Quizzler.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserDbContext _context;

        public UserController(UserDbContext context)
        {
            _context = context;
        }

        //Create

        //Read

        //Update

        //Delete
    }
}
