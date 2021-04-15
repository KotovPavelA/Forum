using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class QSectionAnswer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VolumeOfVote { get; set; }
        public int SectionId { get; set; }
        public QSection Section { get; set; }



    }
}
