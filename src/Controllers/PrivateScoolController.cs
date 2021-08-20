using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace School.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrivateScoolController : ControllerBase
    {
        private AppService service = new AppService();
        string folderName = "private scool";

        [HttpPost]
        public async Task<ActionResult<PrivateStudent>> Post(PrivateSchool users)
        {
            await service.SaveToFile(users, folderName);
            return Ok(users);
        }

        [HttpPost("UploadFile")]
        public async Task<IActionResult> Upload(IFormFile uploadFile)
        {
            if (uploadFile.ContentType != "text/csv") return BadRequest("Wrong file format");
            PrivateSchool school = new PrivateSchool();
            school.ValidateCsvContent(uploadFile);
            if (school.errorData.Count > 0) return BadRequest(school.errorData);
            if (school.users.Count > 0)
                await service.SaveToFile(school, folderName);
            return Ok(school);
        }

    }
}
