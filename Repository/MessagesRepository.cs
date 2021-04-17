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
        private readonly IUsers allUsers;
        public MessagesRepository(ApplicationContext _context, IUsers _users)
        {
            context = _context;
            allUsers = _users;
        }

        public Message CreateMessage(User _user,Section section, string _text)
        {
            Message message = new Message()
            {
                User = _user,
                Text = _text,
                Date = DateTime.Now,
                Section = section,
                SectionId = section.Id
            };
            context.Messages.Add(message);
            context.SaveChanges();

            return message;
        }

        public Message Like(int id, int userId)
        {
            Message message = FindMessageById(id);
            User thisUser = allUsers.FindUserById(userId);

            if(message.Likes.Users.IndexOf(thisUser) == -1)
            {
                message.Likes.Users.Add(thisUser);
                context.SaveChanges();
            }
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
