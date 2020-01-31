using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.UserClasses.DTOs
{
    public class UserDTO
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IsActive { get; set; }
    }
}
