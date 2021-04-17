using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Interfaces
{
    public interface IAllMessages
    {
        public Message CreateMessage(User user,Section section, string text);
        public Message FindMessageById(int id);
        public Message Like(int id, int userId);
        public List<Message> GetAllMessages();
    }
}
