using Quiz.Data;
using System;

namespace Quiz.Services
{
    public class QuizService : IQuizService
    {
        private readonly ApplicationDbContext dbContext;
        public QuizService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(string title)
        {
            var quiz = new Models.Quiz
            {
                Title = title
            };

            this.dbContext.Quizzes.Add(quiz);
            this.dbContext.SaveChanges();
        }
    }
}
