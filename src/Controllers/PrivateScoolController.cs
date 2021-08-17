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
        AppService appService = new AppService();

        [HttpPost]
        public async Task<ActionResult<PrivateStudent>> Post(PrivateSchool users)
        {
            await appService.SaveToFile(users);
            return Ok(users);
        }

        [HttpPost("UploadFile")]
        public async Task<IActionResult> Upload(IFormFile uploadFile)
        {
            using (var streamReader = new StreamReader(uploadFile.OpenReadStream()))
            {
                PrivateSchool school = new PrivateSchool();
                school.users = new List<PrivateStudent>();
                string[] rowData = streamReader.ReadToEnd().Split("\n");
                for (int i = 1; i < rowData.Length; i++)
                {
                    PrivateStudent student = new PrivateStudent();
                    student.setData(rowData[i]);
                    school.users.Add(student);
                }
                await appService.SaveToFile(school);
                return Ok();
            }
        }

    }
}
