using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Services.Users
{
    class UserHandler
    {
        public static User GetCurrentUser()
        {
            var us = new User() { Phone = "", Name = "" };
            return us;
        }
        public static User[] GetAllUsers()
        {
            var us = new User() { Phone = "", Name = "" };
            User[] ar = { us };
            return ar;
        }
    }
    public struct User
    {
        public string Phone;
        public string Name;
    }
}
