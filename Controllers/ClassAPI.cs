using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/v1/class")]
    [ApiController]
    public class ClassAPI : ControllerBase
    {
        MyProjectDbContext context = new MyProjectDbContext();
        [HttpGet]
        public ActionResult GetClassById([FromQuery] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new JsonResult(new
                {
                    EC = -1,
                    EM = "Missing id parameter",
                    DT = "",
                });
            }
            var group = context.ClassEnrolls.Where(s => s.ClassId == Int32.Parse(id)).Select(s => new
            {
                image = "No image",
                username = s.User.Username,
                fullName = s.User.FullName
            }).ToList();
            return new JsonResult(new
            {
                EC = 0,
                EM = "Get class successfully",
                DT = group,
            });
        }
    }
}
