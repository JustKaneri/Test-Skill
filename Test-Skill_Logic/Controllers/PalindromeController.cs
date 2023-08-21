using Microsoft.AspNetCore.Mvc;
using Test_Skill_Logic.Model;

namespace Test_Skill_Logic.Controllers
{
    [ApiController]
    [Route("api/palindrome")]
    public class PalindromeController : Controller
    {
        [HttpPost]
        public IActionResult IsPalindrome(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
                return BadRequest(new RequestAnswer<bool>(false, "Пустая строка"));

            value = value.ToLower();

            string clearStr = string.Join("",value.Where(a => Char.IsLetter(a)).ToList());

            string revStr = string.Join("",clearStr.Reverse());

            return Ok(new RequestAnswer<bool>(revStr == clearStr));
        }
    }
}
