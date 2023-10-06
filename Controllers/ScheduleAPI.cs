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
    }
}
