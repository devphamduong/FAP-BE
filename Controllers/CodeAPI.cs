using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/v1/code")]
    [ApiController]
    public class CodeAPI : ControllerBase
    {
        MyProjectDbContext context = new MyProjectDbContext();

        [HttpGet("slot")]
        public IActionResult GetAllSlot()
        {
            var slots = context.Codes.Where(s => s.Type.Equals("SLOT")).Select(s => new
            {
                code1 = s.Code1,
                description = s.Description,
                time = s.SlotDurations
            }).ToList();
            return new JsonResult(new
            {
                EC = 0,
                EM = "Get all slot successfully",
                DT = slots,
            });
        }
    }
}
