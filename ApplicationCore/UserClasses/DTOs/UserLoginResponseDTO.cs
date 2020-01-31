using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.UserClasses.DTOs
{
   public class UserLoginResponseDTO
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
