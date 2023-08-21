using Microsoft.AspNetCore.Mvc;
using Test_Skill_Logic.Model;

namespace Test_Skill_Logic.Controllers
{
    [Controller]
    [Route("api/sum")]
    public class SumController : Controller 
    {
        [HttpPost]
        [ProducesResponseType(200,Type =  typeof(NumbersArray))]
        public IActionResult GetSumm([FromBody]NumbersArray nums)
        {
            if (nums.numbers.Count == 0)
                return BadRequest(new RequestAnswer<int>(-1, "Пустой массив"));

            IEnumerable<int> beforeSum = nums.numbers.Where(x => x < 0)
                                                        .Where((x, index) => (index+1) % 2 == 0)
                                                        .ToList();
            
            int result = beforeSum.Sum(x => Math.Abs(x));

            return Ok(new RequestAnswer<int>(result));
        }
    }
}
