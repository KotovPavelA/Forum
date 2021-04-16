using Forum.DBContext;
using Forum.Interfaces;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Repository
{
    public class AnswerRepository : IAnswer
    {
        private readonly ApplicationContext context;
        public AnswerRepository(ApplicationContext _context)
        {
            context = _context;
        }

        public int AddVoteToAnswer(int id)
        {
            var answer = context.QSectionAnswers.Find(id);
            answer.VolumeOfVote++;
            context.SaveChanges();
            return answer.SectionId;
        }

        public QSectionAnswer FindAnswerById(int id)
        {
            return context.QSectionAnswers.Find(id);
        }
    }
}
