﻿using ApplicationCore.UserClasses.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.UserClasses
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> Login(UserLoginRequestDTO loginRequestDTO);
    }
}
