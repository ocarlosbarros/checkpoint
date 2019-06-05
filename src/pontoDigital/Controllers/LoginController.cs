using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.AspNetCore.Mvc;

namespace pontoDigital.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}