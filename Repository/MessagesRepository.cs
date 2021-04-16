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
    public class MessagesRepository : IAllMessages
    {
        //Методы для получения сообщений 
        private readonly ApplicationContext context;
        public MessagesRepository(ApplicationContext _context)
        {
            context = _context;
        }

        public Message CreateMessage(User _user,Section section, string _text)
        {
            Message message = new Message()
            {
                User = _user,
                Text = _text,
                Date = DateTime.Now,
                Likes = 0,
                Section = section,
                SectionId = section.Id
            };
            context.Messages.Add(message);
            context.SaveChanges();

            return message;
        }

        public Message Like(int id)
        {
            Message message = FindMessageById(id);
            message.Likes++;
            context.SaveChanges();
            return message;
        }

        public Message FindMessageById(int id)
        {
            return context.Messages.Include(c => c.User).Include(s => s.Section).First(i => i.Id == id);
        }

        public List<Message> GetAllMessages()
        {
            return context.Messages.Include(u => u.User).OrderBy(c => c.User).ToList();
        }
    }
}
