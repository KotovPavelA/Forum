using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }

        public Like Likes { get; set; }
        public string Text { get; set; }
        public string Attachment { get; set; }



    }

}
