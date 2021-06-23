using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzler.Models
{
    public class UserReturnString
    {
        public string Value { get; set; }

        public UserReturnString(int currentCase) 
        {

            switch (currentCase)
            {
                case 1:
                    this.Value = "User Successfully Created.";
                    break;
                case 2:
                    this.Value = "Passwords Did Not Match.";
                    break;
                case 3:
                    this.Value = "UserName Exists.";
                    break;
                case 4:
                    this.Value = "Email Exists.";
                    break;
                default:
                    this.Value = "Invalid Data";
                    break;
            }
        }
    }
}
