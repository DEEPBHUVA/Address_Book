using Addresh_Book5th.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Addresh_Book5th.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}