using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Dapper
{
    public class BaseRepository
    {
        public BaseRepository(IConfiguration configuration)
        {
            SqlServerDbConnection = new SqlConnection(configuration.GetSection("ConnectionStrings").GetSection("Pushlearn_SQLSERVER").Value);
        }

        protected IDbConnection SqlServerDbConnection { get; set; }
    }
}
