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

        public static async Task<User> GetUserByUserName(string username, UserDbContext context) 
        {
            var existingUsers = context.users;
            var newUser = new User();

            foreach (var user in existingUsers) 
            {
                if (user.UserName == username) 
                {
                    newUser = user;
                    return newUser;
                }
            }

            return null;
        }

        public static async Task<User> GetUserById(int id, UserDbContext context)
        {
            var existingUsers = context.users;
            var newUser = new User();

            foreach (var user in existingUsers)
            {
                if (user.Id == id)
                {
                    newUser = user;
                    return newUser;
                }
            }

            return null;
        }

    }
}
