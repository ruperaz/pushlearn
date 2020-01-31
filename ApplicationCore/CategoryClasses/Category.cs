using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.CategoryClasses
{
    public class Category
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int card_count { get; set; }
        public string title { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
