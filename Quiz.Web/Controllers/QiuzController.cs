using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Web.Controllers
{
    public class QiuzController : Controller
    {

        public QiuzController()
        {

        }

        public IActionResult Test(int Id)
        {
            return this.View();
        }

        public IActionResult Results(int Id)
        {
            return this.View();
        }
    }
}
