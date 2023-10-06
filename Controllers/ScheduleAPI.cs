using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/v1/schedule")]
    [ApiController]
    public class ScheduleAPI : ControllerBase
    {
        MyProjectDbContext context = new MyProjectDbContext();

        public class ObjDay
        {
            public string? code { get; set; }
            public object? subject { get; set; }
            public bool? hasEduNext { get; set; }
        }

        [HttpGet]
        public IActionResult GetAllSchedule([FromQuery] string startDate, [FromQuery] string endDate)
        {
            IQueryable<Schedule> query = context.Schedules;
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                query = query.Where(s => s.Date >= DateTime.Parse(startDate) && s.Date <= DateTime.Parse(endDate));
            }
            var schedules = query.Select(s => new
            {
                Id = s.Id,
                name = s.SlotTypeNavigation.Description,
                code = s.SlotTypeNavigation.Code1,
                duration = s.SlotTypeNavigation.SlotDurations.FirstOrDefault(slot => slot.CodeId == s.SlotTypeNavigation.Code1).Duration,
                room = s.Room,
                day = new ObjDay { code = s.DayTypeNavigation.Code1, subject = s.Course, hasEduNext = s.Course.HasEduNext }
            }).ToList();
            return new JsonResult(new
            {
                EC = 0,
                EM = "Get all schedule successfully",
                DT = schedules,
            });
        }

        [HttpGet("detail")]
        public IActionResult GetScheduleById([FromQuery] string id)
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
            var schedule = context.Schedules.Where(s => s.Id == Int32.Parse(id)).Select(s => new
            {
                date = s.Date,
                code = s.SlotTypeNavigation.Code1,
                group = s.Class,
                teacher = s.Teacher,
                course = s.Course.Name,
            }).FirstOrDefault();
            return new JsonResult(new
            {
                EC = 0,
                EM = "Get schedule successfully",
                DT = schedule,
            });
        }
    }
}
