using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.CardClasses
{
    public class Card
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int categoryId { get; set; }
        public int card_level { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
