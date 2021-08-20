using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace School.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController : ControllerBase
    {
        private AppService service = new AppService();
        string folderName = "minstry scool";

        [HttpPost]
        public async Task<ActionResult<Student>> Post(School users)
        {
            await service.SaveToFile(users, folderName);
            return Ok(users);
        }

        [HttpPost("UploadFile")]
        public async Task<IActionResult> Upload(IFormFile uploadFile)
        {
            if (uploadFile.ContentType != "text/csv") return BadRequest("Wrong file format");
            School school = new School();
            school.ValidateCsvContent(uploadFile);

            if (school.errorData.Count > 0) return BadRequest(school.errorData);
            await service.SaveToFile(school, folderName);
            return Ok(school);

        }

    }
}
