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
    public class PrivateScoolController : ControllerBase
    {
        string folderName = "private scool";
        AppService appService = new AppService();

        [HttpPost]
        public async Task<ActionResult<PrivateStudent>> Post(PrivateSchool users)
        {
            await appService.SaveToFile(users, folderName);
            return Ok(users);
        }

        [HttpPost("UploadFile")]
        public async Task<IActionResult> Upload(IFormFile uploadFile)
        {
            if (uploadFile.ContentType != "text/csv") return BadRequest("Wrong file format");

            List<string> errorData = new List<string>();
            using (var streamReader = new StreamReader(uploadFile.OpenReadStream()))
            {
                PrivateSchool school = new PrivateSchool();
                school.users = new List<PrivateStudent>();
                string[] rowData = streamReader.ReadToEnd().Split(Environment.NewLine);
                for (int i = 1; i < rowData.Length; i++)
                {
                    if (rowData[i] != "")
                    {
                        PrivateStudent student = new PrivateStudent();
                        student.setData(rowData[0], rowData[i]);
                        foreach (var item in student.parent)
                        {
                            if(item.invalidFields.Count>0){
                                string errors = string.Join(",", item.invalidFields.ToArray());
                                student.invalidFields.Add(errors);
                            }
                        }
                        if (student.invalidFields.Count > 0)
                        {
                            string errors = string.Join(",", student.invalidFields.ToArray());
                            errorData.Add("Row csv data File[" + (i+1).ToString() + "]: Missing data for: " + errors);
                        }
                        school.users.Add(student);
                    }
                }

                if (errorData.Count > 0) return BadRequest(errorData);
                if (school.users.Count > 0)
                    await appService.SaveToFile(school, folderName);
                return Ok(school);
            }
        }

    }
}
