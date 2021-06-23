using Quizzler.Contexts;
using Quizzler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzler.Logic
{
    public static class UserRepositoryFunctions
    {

        public static async Task CreateUser(User user, UserDbContext context) 
        {
            await context.AddAsync(user);
            await context.SaveChangesAsync();
        }

    }
}
