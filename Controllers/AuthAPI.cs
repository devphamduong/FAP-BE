using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthAPI : ControllerBase
    {
        MyProjectDbContext context = new MyProjectDbContext();
        public class LoginModal
        {
            public string email { get; set; }
            public string password { get; set; }
        }

        public class RegisterModal
        {
            public string email { get; set; }
            public string password { get; set; }
            public string username { get; set; }
            public string fullName { get; set; }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModal data)
        {
            if (string.IsNullOrEmpty(data.email) || string.IsNullOrEmpty(data.password))
            {
                return new JsonResult(new
                {
                    EC = 1,
                    EM = "Missing parameters",
                });
            }
            var user = context.Users.Where(u => u.Email.Equals(data.email) && u.Password.Equals(data.password)).Select(u => new
            {
                id = u.Id,
                email = u.Email,
                username = u.Username,
                fullName = u.FullName,
                gender = u.Gender == true ? "Male" : "Female",
                dob = u.Dob,
                address = u.Address,
                role = u.Role.Name,
            }).FirstOrDefault();
            if (user == null)
            {
                return new JsonResult(new
                {
                    EC = 2,
                    EM = "Wrong email or password",
                });
            }
            return new JsonResult(new
            {
                EC = 0,
                EM = "Login successfully",
                DT = user,
            });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModal data)
        {
            if (string.IsNullOrEmpty(data.email) || string.IsNullOrEmpty(data.password) || string.IsNullOrEmpty(data.username) || string.IsNullOrWhiteSpace(data.fullName))
            {
                return new JsonResult(new
                {
                    EC = 1,
                    EM = "Missing parameters",
                });
            }
            var user = context.Users.Where(u => u.Email.Equals(data.email)).FirstOrDefault();
            if (user != null)
            {
                return new JsonResult(new
                {
                    EC = 2,
                    EM = "This email is already in use by another account",
                });
            }
            return new JsonResult(new
            {
                EC = 0,
                EM = "Register successfully",
            });
        }
    }
}
