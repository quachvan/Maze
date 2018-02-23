using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PeopleNet.Controllers
{
    [Route("api/[controller]")]
    public class SolveMazeController : ControllerBase
    {
        // GET api/SolveMaze
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/SolveMaze/5
        [HttpGet("{id}")]
        public void Get(int id)
        {
        }
        
        // POST api/SolveMaze
        [HttpPost]
        public IActionResult Post([FromBody]Value value)
        {
            if (!ModelState.IsValid || value.Map.Length == 0)
            {
                return BadRequest(ModelState);
            }
            
            string solution = new MazeCalculator(value.Map).RetriveRoute();
            value.Solution = solution;
            value.Steps = solution.Split('@').Length;

            return CreatedAtAction("Get", new { value.Steps, value.Solution}, value);
        }

        // PUT api/SolveMaze/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/SolveMaze/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Value
    {
        public string Map { get; set; }
        public int Steps { get; set; }
        public string Solution { get; set; }
    }
}
