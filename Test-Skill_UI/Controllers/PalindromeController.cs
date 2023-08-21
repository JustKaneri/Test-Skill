using Microsoft.AspNetCore.Mvc;
using Test_Skill_UI.Models;
using Test_Skill_UI.Other;

namespace Test_Skill_UI.Controllers
{
    public class PalindromeController : Controller
    {
        public IActionResult Palindrome()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Palindrome(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return View();

            var responce = await Server.SendRequest<bool>(value.Trim(), @"http://localhost:5144/api/palindrome?value=" + value.Trim());

            if (responce.ErrorContent != null)
                return View(new DataModel() { Result = responce.ErrorContent });

            return View(new DataModel() { Result = responce.Result ? "Да" : "Нет" });
        }
    }
}
