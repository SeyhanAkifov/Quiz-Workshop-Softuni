using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Services.Models;
using Quiz.Services.ViewModels;
using System;
using System.Collections.Generic;
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
        public int Add(string title)
        {
            var quiz = new Quiz.Models.Quiz
            {
                Title = title
            };

            this.dbContext.Quizzes.Add(quiz);
            this.dbContext.SaveChanges();

            return quiz.Id;
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

        public IEnumerable<UserQuizWiewModel> GetQuizzesByUsername(string username)
        {
            var quizzes = dbContext.Quizzes.Select(x => new UserQuizWiewModel()
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();


            foreach (var quiz in quizzes)
            {
                var countQuestions = dbContext.UserAnswers
                    .Count(y => y.IdentityUser.UserName == username
                    && y.Question.QuizId == quiz.Id);

                if (countQuestions == 0)
                {
                    quiz.Status = Quizstatus.NotStarted;
                    continue;
                }

                var countAnswered = dbContext.UserAnswers
                    .Count(y => y.IdentityUser.UserName == username
                    && y.Question.QuizId == quiz.Id
                    && y.AnswerId.HasValue);

                if (countAnswered == countQuestions)
                {
                    quiz.Status = Quizstatus.Finished;
                }
                else
                {
                    quiz.Status = Quizstatus.InProgress;
                    
                }


            }
                return quizzes;
        }

        public void StartQuiz(string username, int quizId)
        {
            if (dbContext.UserAnswers.Any(x => x.IdentityUser.UserName == username && x.Question.QuizId == quizId))
            {
                return;
            }

            string userId = this.dbContext.Users.Where(x => x.UserName == username).Select(x => x.Id).FirstOrDefault();

            var questions = dbContext.Questions
                .Where(x => x.QuizId == quizId)
                .Select(x => new { x.Id}).ToList();

            foreach (var question in questions)
            {
                dbContext.UserAnswers.Add(new Quiz.Models.UserAnswer
                {
                    AnswerId = null,
                    IdentityUserId = userId,
                    QuestionId = question.Id
                });

            }

            dbContext.SaveChanges();
        }
    }
}
