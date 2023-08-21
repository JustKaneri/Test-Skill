using Microsoft.AspNetCore.Mvc;
using Test_Skill_Logic.Model;

namespace Test_Skill_Logic.Controllers
{
    [ApiController]
    [Route("api/sort")]
    public class SortController:Controller
    {
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(NumbersArray))]
        public IActionResult SortNumber([FromBody]NumbersArray array) 
        {
            if (array.numbers.Count == 0)
                return BadRequest(new RequestAnswer<IEnumerable<int>>(null, "Пустой массив"));

            IEnumerable<int> number = array.numbers.OrderBy(x => x).ToList();

            return Ok(new RequestAnswer<IEnumerable<int>>(number));
        }
    }
}
