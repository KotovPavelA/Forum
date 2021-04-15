using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models.ViewModel
{
    public class SelectedSectionViewModel
    {
        public Section Section;

        public List<QSectionAnswer> Variants;
        public List<User> UniqUsers { get; set; }
        public bool Voted { get; set; }

    }
}
