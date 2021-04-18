using Forum.DBContext;
using Forum.Interfaces;
using Forum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Repository
{
    public class ChaptersRepository : IChapter
    {
        private readonly ApplicationContext context;
        public ChaptersRepository(ApplicationContext _context)
        {
            context = _context;
        }

        public Chapter FindChapterById(int id)
        {
            return context.Chapters.Include(s => s.Sections).First(i => i.Id == id);
        }

        public List<Chapter> GetChapters()
        {
            return context.Chapters.Include(s => s.Sections).ToList();
        }
    }
}
