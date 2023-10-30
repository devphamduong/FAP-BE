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
            public string room { get; set; }
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
            if (string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate) || string.IsNullOrEmpty(userId.ToString()))
            {
                return new JsonResult(new
                {
                    EC = -1,
                    EM = "Missing required parameters",
                });
            }
            IQueryable<Schedule> query = context.Schedules;
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                query = context.Schedules.Where(s => s.Date >= DateTime.Parse(startDate) && s.Date <= DateTime.Parse(endDate) && s.UserId == userId);
                if (query.Count() == 0)
                {
                    query = context.Schedules
                        .Where(s => s.Date >= DateTime.Parse(startDate) && s.Date <= DateTime.Parse(endDate))
                        .Include(s => s.Course)
                        .Include(s => s.Class)
                            .Where(s => s.Course.CourseEnrolls.Any(ce => ce.UserId == userId) && s.Class.ClassEnrolls.Any(cle => cle.UserId == userId));
                }
            }
            var schedules = query.Select(s => new
            {
                Id = s.Id,
                name = s.SlotTypeNavigation.Description,
                code = s.SlotTypeNavigation.Code1,
                duration = s.SlotTypeNavigation.SlotDurations.FirstOrDefault(slot => slot.CodeId == s.SlotTypeNavigation.Code1).Duration,
                day = new ObjDay
                {
                    code = s.DayTypeNavigation.Code1,
                    subject = s.Course,
                    hasEduNext = s.Course.HasEduNext,
                    room = s.Room,
                }
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
                    EM = "Missing required parameters",
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
                    EM = "Missing required parameters",
                });
            }
            Schedule schedule = context.Schedules.SingleOrDefault(item => item.Id == data.scheduleId);
            if (schedule != null)
            {
                if (DateTime.Parse(data.date) < schedule.Date)
                {
                    return new JsonResult(new
                    {
                        EC = 2,
                        EM = "Date can only be changed to a future date or today",
                    });
                }
                else
                {
                    DateTime currentDate = DateTime.UtcNow.Date;
                    if (DateTime.Parse(data.date) == currentDate && Int32.Parse(schedule.SlotType.Substring(1)) >= Int32.Parse(data.slot.Substring(1)))
                    {
                        return new JsonResult(new
                        {
                            EC = 3,
                            EM = "Slot must be after current slot",
                        });
                    }
                    else if (DateTime.Parse(data.date) == schedule.Date && Int32.Parse(schedule.SlotType.Substring(1)) == Int32.Parse(data.slot.Substring(1)))
                    {
                        return new JsonResult(new
                        {
                            EC = 4,
                            EM = "New slot is the same as original slot",
                        });
                    }
                    else
                    {
                        if (context.Schedules.Where(s => s.Id != data.scheduleId && s.Date == DateTime.Parse(data.date) && s.SlotType.Equals(data.slot)).Count() == 0)
                        {
                            schedule.Date = DateTime.Parse(data.date);
                            schedule.DayType = data.day;
                            schedule.SlotType = data.slot;
                            context.SaveChanges();
                            return new JsonResult(new
                            {
                                EC = 0,
                                EM = "Updated schedule successfully",
                            });
                        }
                        else
                        {
                            return new JsonResult(new
                            {
                                EC = 5,
                                EM = $"Slot {data.slot.Substring(1)} is already occupied",
                            });
                        }
                    }
                }
            }
            return new JsonResult(new
            {
                EC = 1,
                EM = "Schedule not found",
            });
        }
    }
}
