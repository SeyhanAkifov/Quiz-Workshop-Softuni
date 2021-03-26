using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Quiz.Data;
using Quiz.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Quiz.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            var serviceProvider =  serviceCollection.BuildServiceProvider();

            var json = File.ReadAllText("EF-Core-Quiz.json");
           var questions = JsonConvert.DeserializeObject<IEnumerable<JsonQuestion>>(json);




            //var dbContext = serviceProvider.GetService<ApplicationDbContext>();
            //dbContext.Database.Migrate();

            //var dbContect = serviceProvider.GetService<ApplicationDbContext>();

            var quizServices = serviceProvider.GetService<IQuizService>();
            var questionServices = serviceProvider.GetService<IQuestionService>();
            var answerServices = serviceProvider.GetService<IAnswerService>();
            //var userAnswerServices = serviceProvider.GetService<IUserQuizService>();


            var quizId = quizServices.Add("EF Core Test");

            foreach (var question in questions)
            {
                var questionId = questionServices.Add(question.Question, quizId);

                foreach (var answer in question.Answers)
                {
                    answerServices.Add(answer.Answer, answer.Correct ? 1 : 0, answer.Correct, questionId);
                }
            }

            //quizServices.Add("C# DB");
            //answerServices.Add("It is ORM",1, 5, true);
            //answerServices.Add("It is a OS",1, 0, false);
            //questionServices.Add("2*2", 1);
            //answerServices.Add("4", 14, 5, true);
            //userAnswerServices.AddUserAnswer("f115ecbc-c75e-47ec-b861-eceacd2c28f2", 1,1,4);

            //var quiz = quizServices.GetQuizById(1);
            //var userPoints = userAnswerServices.GetUserResult("f115ecbc-c75e-47ec-b861-eceacd2c28f2", 1);

            //Console.WriteLine(userPoints);

            //Console.WriteLine(quiz.Title);

            //foreach (var question in quiz.Questions)
            //{
            //    Console.WriteLine(question.Title);

            //    foreach (var answer in question.Answers)
            //    {
            //        Console.WriteLine(answer.Title);
            //    }
            //}

        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<IQuizService, QuizService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IAnswerService, AnswerService>();
            services.AddTransient<IUserQuizService, UserQuizService>();
        }
    }
}
