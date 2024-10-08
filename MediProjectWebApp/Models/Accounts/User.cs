﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediProjectWebApp.Models.Accounts
{
    public class User
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
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