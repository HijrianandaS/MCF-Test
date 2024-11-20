using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Account()
        {
            return View();
        }
    }
}
