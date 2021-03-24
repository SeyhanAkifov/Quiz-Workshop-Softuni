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

            //var quizServices = serviceProvider.GetService<IQuizService>();
            var questionServices = serviceProvider.GetService<IQuestionService>();

            //quizServices.Add("C# DB");
            questionServices.Add("Waht is Entity Framework", 1);


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
        }
    }
}
