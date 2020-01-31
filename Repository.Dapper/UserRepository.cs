using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.UserClasses;
using ApplicationCore.UserClasses.DTOs;

namespace Repository.Dapper
{
    public class UserRepository : BaseRepository, IUserRepository
    {

        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<User>> GetAll()
        {
            var query = "select * from Users";
            return (await SqlServerDbConnection.QueryAsync<User>(query)).ToList();
        }


        public async Task<User> Login(UserLoginRequestDTO loginRequestDTO)
        {
            var query = "select * from Users where username=@username and password =@password";
            return (await SqlServerDbConnection.QueryAsync<User>(query,new { username=loginRequestDTO.UserName , password= loginRequestDTO.Password })).FirstOrDefault();
        }
    }
}
