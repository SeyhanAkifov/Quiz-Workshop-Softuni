using Quiz.Data;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly ApplicationDbContext dbContext;
        public AnswerService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public int Add(string title, int questionId, int points, bool isCorrect)
        {
            var answer = new Answer
            {
                Title = title,
                Points = points,
                QuestionId = questionId,
                IsCorrect = isCorrect
            };

            this.dbContext.Answers.Add(answer);
            this.dbContext.SaveChanges();

            return answer.Id;
        }
    }
}
