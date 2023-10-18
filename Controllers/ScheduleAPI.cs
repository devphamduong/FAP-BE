using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public class ObjUpdateSchedule
        {
            public int scheduleId { get; set; }
            public string? date { get; set; }
            public string? day { get; set; }
            public string? slot { get; set; }
        }

        [HttpGet]
        public IActionResult GetAllSchedule([FromQuery] int userId, [FromQuery] string startDate, [FromQuery] string? endDate)
        {
            IQueryable<Schedule> query = context.Schedules.Include(s => s.Course).ThenInclude(c => c.CourseEnrolls);
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                query = query.Where(s => s.Date >= DateTime.Parse(startDate) && s.Date <= DateTime.Parse(endDate) && s.UserId == userId);
            }
            var schedules = query.Select(s => new
            {
                Id = s.Id,
                name = s.SlotTypeNavigation.Description,
                code = s.SlotTypeNavigation.Code1,
                duration = s.SlotTypeNavigation.SlotDurations.FirstOrDefault(slot => slot.CodeId == s.SlotTypeNavigation.Code1).Duration,
                room = s.Room,
                day = new ObjDay { code = s.DayTypeNavigation.Code1, subject = s.Course, hasEduNext = s.Course.HasEduNext }
            }).Distinct().ToList();
            return new JsonResult(new
            {
                EC = 0,
                EM = "Get all schedule successfully",
                DT = schedules,
            });
        }

        [HttpGet("teacher")]
        public IActionResult GetAllScheduleForTeacher([FromQuery] string startDate, [FromQuery] string? teacherId)
        {
            if (string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(teacherId))
            {
                return new JsonResult(new
                {
                    EC = -1,
                    EM = "Missing id parameter",
                });
            }
            IQueryable<Schedule> query = context.Schedules;
            if (!string.IsNullOrEmpty(startDate))
            {
                query = query.Where(s => s.Date >= DateTime.Parse(startDate) && s.UserId == Int32.Parse(teacherId));
            }
            var schedules = query.Select(s => new
            {
                Id = s.Id,
                date = s.Date,
                name = s.SlotTypeNavigation.Description,
                code = s.SlotTypeNavigation.Code1,
                duration = s.SlotTypeNavigation.SlotDurations.FirstOrDefault(slot => slot.CodeId == s.SlotTypeNavigation.Code1).Duration,
                room = s.Room,
                day = new ObjDay { code = s.DayTypeNavigation.Code1, subject = s.Course, hasEduNext = s.Course.HasEduNext }
            }).ToList();
            return new JsonResult(new
            {
                EC = 0,
                EM = "Get all schedule for teacher successfully",
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
                });
            }
            var schedule = context.Schedules.Where(s => s.Id == Int32.Parse(id)).Select(s => new
            {
                date = s.Date,
                code = s.SlotTypeNavigation.Code1,
                group = s.Class,
                teacher = s.User,
                course = s.Course.Name,
            }).FirstOrDefault();
            return new JsonResult(new
            {
                EC = 0,
                EM = "Get schedule successfully",
                DT = schedule,
            });
        }

        [HttpPut]
        public IActionResult ChangeSchedule([FromBody] ObjUpdateSchedule data)
        {
            if (string.IsNullOrEmpty(data.scheduleId.ToString()) || string.IsNullOrEmpty(data.date.ToString()) || string.IsNullOrEmpty(data.day) || string.IsNullOrEmpty(data.slot))
            {
                return new JsonResult(new
                {
                    EC = -1,
                    EM = "Missing required parameter",
                });
            }
            Schedule schedule = context.Schedules.SingleOrDefault(item => item.Id == data.scheduleId);
            if (schedule != null)
            {
                schedule.Date = DateTime.Parse(data.date);
                schedule.DayType = data.day;
                schedule.SlotType = data.slot;
                context.SaveChanges();
                return new JsonResult(new
                {
                    EC = 0,
                    EM = "Update schedule successfully",
                });
            }
            return new JsonResult(new
            {
                EC = 1,
                EM = "Schedule not found",
            });
        }
    }
}
