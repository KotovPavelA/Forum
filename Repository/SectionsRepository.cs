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

        private readonly ApplicationContext context;
        public SectionsRepository(ApplicationContext _context)
        {
            context = _context;
        }
        public IEnumerable<Section> GetAllSectionsForList => context.Sections;

        public IEnumerable<QSection> GetGetQSections()
        {
            return context.Sections.OfType<QSection>(); //Получить только опросники
        }

        public Section FindSectionById(int i)
        {
           var section = context.Sections.Include(c => c.Messages).First(c => c.Id == i);
           if(section.Discriminator == "QSection")
           {
                return null;
           }
           else
           {
                section.Messages = context.Messages
                .Include(u => u.User)
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
    }
}
