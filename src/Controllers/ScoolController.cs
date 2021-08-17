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
            List<string> errorData = new List<string>();
            using (var streamReader = new StreamReader(uploadFile.OpenReadStream()))
            {
                School school = new School();
                school.users = new List<Student>();
                string[] rowData = streamReader.ReadToEnd().Split(Environment.NewLine);
                for (int i = 1; i < rowData.Length; i++)
                {
                    if (rowData[i] != "")
                    {
                        Student student = new Student();
                        student.setData(rowData[0], rowData[i]);
                        if (student.invalidFields.Count > 0)
                        {
                            string errors = string.Join(",", student.invalidFields.ToArray());
                            errorData.Add("Student[" + i.ToString() + "]: Missing data for: " + errors);
                        }
                        school.users.Add(student);
                    }
                }
                await appService.SaveToFile(school);
                return Ok();
            }

        }

    }
}
