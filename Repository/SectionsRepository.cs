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
    public class SectionsRepository : IAllSections
    {
        //Методы для получения разделов форума
        private readonly IUsers allUsers;
        private readonly IChapter allChapters;

        private readonly ApplicationContext context;
        public SectionsRepository(ApplicationContext _context, IUsers _users, IChapter chapter)
        {
            context = _context;
            allUsers = _users;
            allChapters = chapter;

        }
        public IEnumerable<Section> GetAllSectionsForList => context.Sections.Include(u => u.Creater);

        public IEnumerable<QSection> GetGetQSections()
        {
            return context.Sections.OfType<QSection>(); //Получить только опросники
        }

        public Section FindSectionById(int i)
        {
           var section = context.Sections.Include(c => c.Creater).Include(c => c.Messages).First(c => c.Id == i);
           if(section.Discriminator == "QSection")
           {
                return null;
           }
           else
           {
                section.Messages = context.Messages
                .Include(u => u.User)
                .Include(l => l.Likes)
                .Where(s => s.SectionId == section.Id)
                .OrderBy(d => d.Date).ToList();//Встраиваем те же самые сообщения, но отсортированные по дате
                return section;
           }
        }

        public QSection FindQSectionById(int i)
        {
            QSection section = context.QSections
                .Include(c => c.Messages)
                .Include(v => v.Variants)
                .Include(u => u.UniqUsers)
                .First(c => c.Id == i);
            section.Messages = context.Messages
                .Include(u => u.User)
                .Where(s => s.SectionId == section.Id)
                .OrderBy(d => d.Date).ToList();//Встраиваем те же самые сообщения, но отсортированные по дате
            return section;

        }

        public Section CreateSection(int id,string Name, int UserId)
        {
            Chapter chapter = allChapters.FindChapterById(id);
            User user = allUsers.FindUserById(UserId);
            Section section = new Section()
            {
                Name = Name,
                Creater = user,
                Chapter = chapter
            };
            context.Sections.Add(section);
            context.SaveChanges();
            return section;
        }


        public QSection CreateQSection(int id, string Name, int UserId)
        {
            Chapter chapter = allChapters.FindChapterById(id);
            User user = allUsers.FindUserById(UserId);
            QSection qsection = new QSection()
            {
                Name = Name,
                Creater = user,
                Chapter = chapter
            };
            context.QSections.Add(qsection);
            context.SaveChanges();
            return qsection;
        }
    }
}
