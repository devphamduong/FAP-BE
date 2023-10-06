using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserAPI : ControllerBase
    {
        MyProjectDbContext context = new MyProjectDbContext();
        [HttpGet]
        public IActionResult GetUserById([FromQuery] string id)
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
            var teacher = context.Users.Where(s => s.Id == Int32.Parse(id)).FirstOrDefault();
            return new JsonResult(new
            {
                EC = 0,
                EM = "Get user successfully",
                DT = teacher,
            });
        }
    }
}
