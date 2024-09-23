using MediProjectWebApp.Helpers;
using MediProjectWebApp.Models.Accounts;
using MediProjectWebApp.Services.Interfaces;
using Npgsql;
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
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(@"SELECT Count(id) as adminCount
                                                       FROM users
                                                      WHERE username = :userName
                                                        AND password_hash = crypt(:password, password_hash);", conn))
                {
                    cmd.Parameters.Add(new NpgsqlParameter(":userName", user.Username));
                    cmd.Parameters.Add(new NpgsqlParameter(":password", user.Password));
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return (Convert.ToInt64(reader["adminCount"]) == 1 ? QueryStatus.Success : QueryStatus.Failed);
                        }
                    }
                }
            }
            return QueryStatus.Failed;
        }
    }
}