using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Services.Users
{
    class UserHandler
    {
        public static User GetCurrentUser()
        {
            var us = new User() { phone = "", name = "" };
            return us;
        }
        public static User[] GetAllUsers()
        {
            var us = new User() { phone = "", name = "" };
            User[] ar = { us };
            return ar;
        }
    }
    public struct User
    {
        public string phone;
        public string name;
    }
}
