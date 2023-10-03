using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/v1/schedule")]
    [ApiController]
    public class ScheduleAPI : ControllerBase
    {
        MyProjectDbContext context = new MyProjectDbContext();
        public class Object
        {
            public string code { get; set; }
            public object subject { get; set; }
        }
        [HttpGet]
        public IActionResult GetAllSchedule()
        {
            var schedules = context.Schedules.Select(s => new
            {
                name = s.SlotTypeNavigation.Description,
                code = s.SlotTypeNavigation.Code1,
                day = new List<Object>
                {
                    new Object {code = s.DayTypeNavigation.Code1, subject= s.Course}
                },
            }).ToList();
            return new JsonResult(new
            {
                EC = 0,
                EM = "Get all schedule successfully",
                DT = schedules,
            });
        }
    }
}
