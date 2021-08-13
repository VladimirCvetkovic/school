using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace School.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Student
            {
                Firstname = "Vladimir"
            })
            .ToArray();
        }

        [HttpPost]
        public async Task<ActionResult<Student>> Post(Student student)
        {
            Console.Write(student);
            return Ok();
        }

    }
}
