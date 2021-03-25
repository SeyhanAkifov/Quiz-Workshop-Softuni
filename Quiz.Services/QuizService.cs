using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Services.Models;
using System;
using System.Linq;

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
            var quiz = new Quiz.Models.Quiz
            {
                Title = title
            };

            this.dbContext.Quizzes.Add(quiz);
            this.dbContext.SaveChanges();
        }

        public QuizViewModel GetQuizById(int quizId)
        {
            var quiz = this.dbContext.Quizzes
                .Include(x => x.Questions)
                .ThenInclude(x => x.Answers)
                .FirstOrDefault(x => x.Id == quizId);

            var quizViewModel = new QuizViewModel
            {
                Id = quiz.Id,
                Title = quiz.Title,
                Questions = quiz.Questions.Select(x => new QuestionViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Answers = x.Answers.Select(y => new AnswerViewModel()
                    {
                        Id = y.Id,
                        Title = y.Title

                    })
                })
            };

            return quizViewModel;
        } 

       
    }
}
