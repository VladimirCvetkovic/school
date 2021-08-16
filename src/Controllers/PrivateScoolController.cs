using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;

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
            PrivateSchool privateSchool = new PrivateSchool();
            using (var streamReader = new StreamReader(uploadFile.OpenReadStream()))
            {
                string[] rowData = streamReader.ReadToEnd().Split("/n");

                for (int i = 0; i < rowData.Length; i++)
                {
                    PrivateStudent student = new PrivateStudent();
                    student.setData(rowData[i]);
                    privateSchool.users[i] = student;
                }

            }
            await appService.SaveToFile(privateSchool);
            return Ok();
        }

    }
}
