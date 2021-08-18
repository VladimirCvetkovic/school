using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
            if(uploadFile.ContentType!= "text/csv") return BadRequest("Wrong file format");
            
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

                        if(student.parent.invalidFields.Count > 0){
                            string errors = string.Join(",", student.parent.invalidFields.ToArray());
                            student.invalidFields.Add(errors);
                        }

                        if (student.invalidFields.Count > 0)
                        {
                            string errors = string.Join(",", student.invalidFields.ToArray());
                            errorData.Add("Row csv data File[" + (i + 1).ToString() + "]: Missing data for: " + errors);
                        }
                        school.users.Add(student);
                    }
                }
                if(errorData.Count > 0) return BadRequest(errorData);
                await appService.SaveToFile(school);
                return Ok(school);
            }

        }

    }
}
