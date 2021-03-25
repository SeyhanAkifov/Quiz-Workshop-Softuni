using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Data;
using Quiz.Services;
using System;
using System.IO;

namespace Quiz.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            var serviceProvider =  serviceCollection.BuildServiceProvider();

            //var dbContect = serviceProvider.GetService<ApplicationDbContext>();

            var quizServices = serviceProvider.GetService<IQuizService>();
            //var questionServices = serviceProvider.GetService<IQuestionService>();
            //var answerServices = serviceProvider.GetService<IAnswerService>();
            //var userAnswerServices = serviceProvider.GetService<IUserQuizService>();

            //quizServices.Add("C# DB");
            //answerServices.Add("It is ORM",1, 5, true);
            //answerServices.Add("It is a OS",1, 0, false);
            //userAnswerServices.AddUserAnswer("f115ecbc-c75e-47ec-b861-eceacd2c28f2", 1,1,3);


            var quiz = quizServices.GetQuizById(1);

            Console.WriteLine(quiz.Title);

            foreach (var question in quiz.Questions)
            {
                Console.WriteLine(question.Title);

                foreach (var answer in question.Answers)
                {
                    Console.WriteLine(answer.Title);
                }
            }

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
