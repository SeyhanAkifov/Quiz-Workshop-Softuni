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

        public QuizController(IQuizService quizService)
        {
            this.quizService = quizService;
        }

        public IActionResult Test(int id)
        {
            this.quizService.StartQuiz(this.User?.Identity?.Name, id);
            var viewModel = this.quizService.GetQuizById(id);

            return this.View(viewModel);
        }

        public IActionResult Results(int id)
        {
            return this.View();
        }
    }
}
