using BackendMCF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendMCF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string username, string password)
        {
            var user = _context.MsUsers.FirstOrDefault(u => u.UserName == username && u.Password == password);

            if (user == null || !user.IsActive)
                return Unauthorized("Invalid credentials or inactive user.");

            return Ok(new { Message = "Login Successful", User = user });
        }
    }
}
