using HR_Management.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HR_Management.MVC.Controllers
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