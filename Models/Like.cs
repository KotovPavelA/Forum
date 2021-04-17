using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Like
    {
        public int Id { get; set; }
        public List<User> Users { get; set; }
        public int Volume 
        { get
            {
                return Users.Count;
            }
        }
    }
}
