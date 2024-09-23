using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MediProjectWebApp.Helpers
{
    public abstract class ConnectionStringHelper
    {
        public string connString = ConfigurationManager.ConnectionStrings["MedDBConnection"].ConnectionString;
    }
}