using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Services
{
    public interface IUserQuizService
    {
        void AddUserAnswer(string userId, int quizId , int questionId, int answerId);
    }
}
