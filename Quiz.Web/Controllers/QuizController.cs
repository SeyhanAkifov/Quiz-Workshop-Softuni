using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Web.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        private readonly IQuizService quizService;
        private readonly IUserQuizService userQuizService;

        public QuizController(IQuizService quizService, IUserQuizService userQuizService)
        {
            this.quizService = quizService;
            this.userQuizService = userQuizService;
            this.userQuizService = userQuizService;
        }

        public IActionResult Test(int id)
        {
            this.quizService.StartQuiz(this.User?.Identity?.Name, id);
            var viewModel = this.quizService.GetQuizById(id);

            return this.View(viewModel);
        }

        public IActionResult Submit(int id)
        {
            foreach (var item in this.Request.Form)
            {
                var questionId = int.Parse(item.Key.Replace("q_", string.Empty));
                var answerId = int.Parse(item.Value);
                this.userQuizService.AddUserAnswer(this.User.Identity.Name, questionId, answerId);
            }


            return this.RedirectToAction("Results", new { id });
        }

        public IActionResult Results(int id)
        {
            var points = this.userQuizService.GetUserResult(this.User.Identity.Name, id);
            return this.View(points);
        }
    }
}
