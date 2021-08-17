using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;

namespace School.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController : ControllerBase
    {
        AppService appService = new AppService();

        [HttpPost]
        public async Task<ActionResult<Student>> Post(School users)
        {
            await appService.SaveToFile(users);
            return Ok(users);
        }

        [HttpPost("UploadFile")]
        public async Task<IActionResult> Upload(IFormFile uploadFile)
        {
            using (var streamReader = new StreamReader(uploadFile.OpenReadStream()))
            {
                School school = new School();
                school.users = new List<Student>();
                string[] rowData = streamReader.ReadToEnd().Split("\n");
                for (int i = 1; i < rowData.Length; i++)
                {
                    Student student = new Student();
                    student.setData(rowData[0], rowData[i]);
                    school.users.Add(student);
                }
                await appService.SaveToFile(school);
                return Ok();
            }

        }

    }
}
