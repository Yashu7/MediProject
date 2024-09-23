using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediProjectWebApp.Models.Accounts
{
    public class User
    {
        public long Id { get; private set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public User()
        {

        }
        public User(long id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }
    }
}