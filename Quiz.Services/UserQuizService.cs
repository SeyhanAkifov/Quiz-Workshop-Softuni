using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Models;
using Quiz.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Services
{
    public class UserQuizService : IUserQuizService
    {
        private readonly ApplicationDbContext dbContext;
        public UserQuizService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddUserAnswer(string userId, int questionId,int answerId)
        {
            var userAnswer = new UserAnswer
            {
                IdentityUserId = userId,
                AnswerId = answerId,
                QuestionId = questionId
            };

            this.dbContext.UserAnswers.Add(userAnswer);
            this.dbContext.SaveChanges();

           
        }

        public void BulkAddUserAnswer(QuizInputModel quizInputModel)
        {
            var userAnswers = new List<UserAnswer>();

            foreach (var question in quizInputModel.Questions)
            {
                var userAnswer = new UserAnswer
                {
                    IdentityUserId = quizInputModel.UserId,
                    AnswerId = question.AnswerId,
                    QuestionId = question.QuestionId
                };

                userAnswers.Add(userAnswer);
            }

            this.dbContext.AddRange(userAnswers);
            this.dbContext.SaveChanges();
        }

        public int GetUserResult(string userId, int quizId)
        {
            var totalPoints = this.dbContext.UserAnswers
                .Where(x => x.IdentityUserId == userId && x.Question.QuizId == quizId)
                .Sum(x => x.Answer.Points);

            return totalPoints;
        }


    }
}
