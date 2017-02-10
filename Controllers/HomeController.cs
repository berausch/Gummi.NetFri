using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gummi.Models;


namespace Gummi.Controllers
{
    public class HomeController : Controller
    {

        private GummiContext db = new GummiContext();
        public IActionResult Index()
        {
            return View();
        }
    }
}
