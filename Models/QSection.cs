using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class QSection:Section
    {
        public List<QSectionAnswer> Variants { get; set; }
        public List<User> UniqUsers { get; set; }

    }
}
