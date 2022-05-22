using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CETask.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CETask.Controllers
{
    public class SignUpController : Controller
    {
        // GET: /<controller>/
        public IActionResult Teacher()
        {
            return View(new Teacher());
        }
        public IActionResult Pupil()
        {
            return View(new Pupil());
        }
    }
}
