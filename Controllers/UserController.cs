using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

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
                firstname = "Vladimir"
            })
            .ToArray();
        }

        [HttpPost]
        public async Task<ActionResult<Student>> Post(Users users)
        {
            var myJObject = JObject.Parse(users);
            Console.Write(myJObject);
            // CreateFile(users);
            return Ok(users);
        }

        // public void CreateFile(Users users) 
        // {
        //     JObject obj = (JObject)JToken.FromObject(users);
        //     string uploadDir = Path.Combine(WebHostEnviroment.WebRootPath, "Json");
        //     string fileName = GetTimestamp(DateTime.Now) + ".json";
        //     string filePath = Path.Combine(uploadDir,fileName);
        //     File.WriteAllText(filePath, obj.toStrint());
        // }

    }
}
