using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ApplicationCore.UserClasses;
using ApplicationCore.UserClasses.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;


using WebAPI.Utils;

using WebAPI.Utils.jwt;


namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private IUserService Service { get; }
        private IConfiguration Configuration { get; }
        private readonly JWTHandler _JWTHandler;
       
        public AuthController(ILogger<AuthController> logger,IUserService service, IConfiguration configuration, JWTHandler jWTHandler)
        {
            Service = service;
            Configuration = configuration;
            _JWTHandler = jWTHandler;
            _logger = logger;
        }
        [HttpPost]
        public async Task<ActionResult<UserLoginResponseDTO>> Login(UserLoginRequestDTO user)
        {
            var userResult = await Service.Login(user);
            if (userResult == null) //User login failed
                return StatusCode(403,new { message = "نام کاربری اشتباه وارد شده" });
            else if (userResult.IsActive == false)
                return StatusCode(403, new { message = "کاربر غیر فعال شده است" });
            else if (userResult.Password != user.Password)
                return StatusCode(403, new { message = "رمز عبور اشتباه است" });
            else
            {
                var tokenString = GenerateToken(userResult);
                return Ok(new UserLoginResponseDTO()
                {
                    AccessToken = tokenString,
                    RefreshToken = string.Empty,
                });

            }

        }

        private string GenerateToken(User userFromRepo)
        {
            var Claims = new List<Claim>{
                                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                               ,new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),
                               new Claim(ClaimTypes.Name,userFromRepo.UserName),
                };
            return _JWTHandler.GenerateJSONWebToken(Claims);
        }

    }
}