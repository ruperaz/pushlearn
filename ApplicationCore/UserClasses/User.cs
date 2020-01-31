using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.UserClasses
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
