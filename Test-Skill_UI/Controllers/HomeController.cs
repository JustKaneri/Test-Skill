using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Test_Skill_UI.Extension;
using Test_Skill_UI.Models;
using Test_Skill_UI.Other;

namespace Test_Skill_UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return View();

            value = value.ClearDoubleSpace();

            var numArr = value.Split(' ').Where(x => int.TryParse(x,out int b)).Select(x => int.Parse(x));

            var responce = await Server.SendRequest<int>(new { numbers = numArr }, @"http://localhost:5144/api/sum");

            if(responce.ErrorContent!= null)
                return View(new DataModel() { Result = responce.ErrorContent });

            return View(new DataModel() { Result = responce.Result.ToString()});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}