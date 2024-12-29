using B201210597.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace B201210597.Controllers
{


    [Authorize]
    public class KontrolPaneliDenetleyiciController : Controller
    {

        private readonly DatabaseContext _db;


        public KontrolPaneliDenetleyiciController(DatabaseContext db)
        {
            _db = db;
        }

        public IActionResult Display()
        {



            if (User.IsInRole("admin"))
            {

                return RedirectToAction("Display", "Admin");

            }
            return View();
        }

        public IActionResult Display1()
        {



            if (User.IsInRole("admin"))
            {

                return RedirectToAction("Display", "Admin");

            }
            return View();
        }

        public IActionResult Index()
        {




            return View();
        }
    }
}
