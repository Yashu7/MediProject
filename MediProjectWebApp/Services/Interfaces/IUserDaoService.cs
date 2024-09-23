using MediProjectWebApp.Helpers;
using MediProjectWebApp.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediProjectWebApp.Services.Interfaces
{
    public interface IUserDaoService
    {
        QueryStatus LoginUser(User user);
    }
}
