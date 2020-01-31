using ApplicationCore.UserClasses.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.UserClasses
{
    public class UserService : IUserService
    {

        public UserService(IUserRepository repository)
        {
            Repository = repository;
        }

        public IUserRepository Repository { get; }

        public async Task<List<User>> GetAll()
        {
            return await Repository.GetAll();
        }

        public async Task<User> Login(UserLoginRequestDTO loginRequestDTO)
        {
            return await Repository.Login(loginRequestDTO);
        }

    }
}
