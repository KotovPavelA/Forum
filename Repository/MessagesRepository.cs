using Forum.DBContext;
using Forum.Interfaces;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Repository
{
    public class MessagesRepository /*: IAllMessages*/
    {
        //Методы для получения сообщений 
        private readonly ApplicationContext context;
        public MessagesRepository(ApplicationContext _context)
        {
            context = _context;
        }
        
    }
}
