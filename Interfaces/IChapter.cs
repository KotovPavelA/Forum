using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Interfaces
{
    public interface IChapter
    {
        public Chapter FindChapterById(int id);
        public List<Chapter> GetChapters();
    }
}
