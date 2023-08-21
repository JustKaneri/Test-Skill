using Microsoft.AspNetCore.Mvc;
using Test_Skill_UI.Extension;
using Test_Skill_UI.Models;
using Test_Skill_UI.Other;

namespace Test_Skill_UI.Controllers
{
    public class SortController : Controller
    {
        public IActionResult Sort()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Sort(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return View();

            value = value.ClearDoubleSpace();

            var numArr = value.Split(' ').Where(x => int.TryParse(x, out int b)).Select(x => int.Parse(x));

            var responce = await Server.SendRequest<IEnumerable<int>>(new { numbers = numArr }, @"http://localhost:5144/api/sort");

            if (responce.ErrorContent != null)
                return View(new DataModel() { Result = responce.ErrorContent });

            return View(new DataModel() { Result = string.Join(" ", responce.Result) });
        }
    }
}
