using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzler.Models
{
    public static class UserConstants
    {
        public static string Ok { get; private set; } = "User Sucessfully Created.";
        public static string SuccessMessage { get; private set; } = "Success";
        public static string InvalidUser { get; private set; } = "The User Does Not Exist.";
        public static string InvalidData { get; private set; } = "Invalid Data";
        public static string EmailExist { get; private set; } = "Email already in use.";
        public static string UserNameExist { get; private set; } = "UserName already in use";
        public static string PasswordMismatch { get; private set; } = "Passwords Do Not Match";
    }
}
