using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreaterId { get; set; }
        public User Creater { get; set; }
        public List<Message> Messages { get; set; }
        public string Discriminator { get; set; }

    }
}
