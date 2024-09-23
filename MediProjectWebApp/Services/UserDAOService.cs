using MediProjectWebApp.Helpers;
using MediProjectWebApp.Models.Accounts;
using MediProjectWebApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediProjectWebApp.Services
{
    public class UserDAOService : ConnectionStringHelper, IUserDaoService
    {
        public QueryStatus LoginUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}