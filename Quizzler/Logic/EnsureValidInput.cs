﻿using Quizzler.Contexts;
using Quizzler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzler.Logic
{
    public static class EnsureValidInput
    {
        public static string EnsureUserData(User newUser, string confPassword, UserDbContext context) 
        {

            if (String.IsNullOrWhiteSpace(newUser.UserName) || String.IsNullOrWhiteSpace(newUser.Password)
                || String.IsNullOrWhiteSpace(newUser.Email))
            {
                return new UserReturnString(0).Value;
            }
            else if (newUser.Password != confPassword)
            {
                return new UserReturnString(2).Value;
            }
            if (newUser.UserName.Length > 0)
            {
                var existingUsers = context.users;

                foreach (var user in existingUsers) 
                {
                    if (user.UserName == newUser.UserName)
                    {
                        return new UserReturnString(3).Value;
                    }
                }
            }
            if (newUser.Email.Length > 0)
            {
                var existingUsers = context.users;

                foreach (var user in existingUsers)
                {
                    if (user.Email == newUser.Email)
                    {
                        return new UserReturnString(4).Value;
                    }
                }


            }

            return new UserReturnString(1).Value;
        }
    }
}