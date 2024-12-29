using Microsoft.AspNetCore.Mvc;

namespace B201210597.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
