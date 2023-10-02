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
            //    {
            //    name: "Slot 0",
            //    code: "S0",
            //    day:
            //        [
            //        {
            //        code: "MON", subject: []
            //        },
            //        {
            //        code: "TUE", subject: []
            //        },
            //        {
            //        code: "WED", subject: []
            //        },
            //        {
            //        code: "THU", subject: []
            //        },
            //        {
            //        code: "FRI", subject: []
            //        },
            //        {
            //        code: "SAT", subject: []
            //        },
            //        {
            //        code: "SUN", subject: []
            //        },
            //    ]
            //}
            var schedules = context.Schedules.Select(s => new
            {
                slot = s.SlotTypeNavigation.Description,
                code = s.SlotTypeNavigation.Code1,
                day = new List<Object>
                {
                    new Object {code = s.DayTypeNavigation.Description, subject= s.Course}
                },
            }).ToList();
            return Ok(schedules);
        }
    }
}
