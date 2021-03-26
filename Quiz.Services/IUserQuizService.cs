using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Services
{
    public interface IUserQuizService
    {
        void AddUserAnswer(string userId,int questionId, int answerId);

        public int GetUserResult(string userId, int quizId);
    }
}
