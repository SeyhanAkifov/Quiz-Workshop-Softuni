using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Services.ViewModels
{
    public class UserQuizWiewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Quizstatus Status { get; set; }
    }

    public enum Quizstatus
    {
        NotStarted = 1,
        InProgress = 2,
        Finished = 3

    }
}
