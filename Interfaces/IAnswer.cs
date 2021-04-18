using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Interfaces
{
    public interface IAnswer
    {
        QSectionAnswer FindAnswerById(int id);
        int AddVoteToAnswer(int id); //Метод для голосования в опросниках
    }
}
