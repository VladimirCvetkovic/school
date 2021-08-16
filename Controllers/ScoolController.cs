using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using CsvHelper;
using System.Globalization;
using Microsoft.AspNetCore.Http;

namespace School.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController : ControllerBase
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
        public async Task<ActionResult<Student>> Post(School users)
        {
            var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

            string docPath = Environment.CurrentDirectory + "\\output";
            string fileName = Timestamp.ToString() + ".json";

            if (!Directory.Exists(docPath)) Directory.CreateDirectory(docPath);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, fileName)))
            {
                string jsonString = JsonSerializer.Serialize(users);
                await outputFile.WriteAsync(jsonString);
            }
            Console.WriteLine(Timestamp.ToString());
            Console.WriteLine(DateTimeOffset.FromUnixTimeSeconds(Timestamp));
            Console.WriteLine(DateTimeOffset.FromUnixTimeSeconds(Timestamp).ToLocalTime());
            return Ok(users);
        }

        [HttpPost("upload")]
        public IActionResult Upload(IFormFile uploadFile)
        {
            using (var streamReader = new StreamReader(uploadFile.OpenReadStream())){
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture)){
                    var records = csvReader.GetRecords<dynamic>().ToList();
                }
            }
            return Ok();
        }

    }
}
