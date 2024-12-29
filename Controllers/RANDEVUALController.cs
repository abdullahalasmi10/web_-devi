using B201210597.Models.Domain; 
using B201210597.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace B201210597.Controllers
{
    [Authorize]

    public class RandevuAlController : Controller
    {

        private readonly DatabaseContext _db;

        public RandevuAlController(DatabaseContext db)
        {
            _db = db;
        }

 
        public IActionResult cikis()
        {
            return RedirectToAction("Logout", "UserAuthentication");
        }

        public IActionResult Index()
        {
            SonRandevu viewModel = new SonRandevu
            {
                Departments = _db.Departments.ToList(),
                salons = _db.salons.ToList(),
                koafors = _db.koafors.ToList()
                
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(SonRandevu obj)
        {
            
            _db.Randevular.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Randevu Alindi";
            return RedirectToAction("Yazdir", obj);

        }

        public IActionResult Yazdir(SonRandevu obj)
        {

         //   var appointment = _db.Randevular.FirstOrDefault(r => r.id == id);

            //if (appointment == null)
            //{
            //    return NotFound(); 
            //}

            return View(obj);

        }
    }
}
