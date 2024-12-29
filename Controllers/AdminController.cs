using B201210597.Models.Domain;
using B201210597.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace B201210597.Controllers
{
    [Authorize(Roles = "admin")]

    public class AdminController : Controller
    {

        private readonly DatabaseContext _db;

        public AdminController(DatabaseContext db)
        {
            _db = db;
        }
        public IActionResult cikis()
        {
            return RedirectToAction("Logout", "UserAuthentication");
        }
        public IActionResult Display()
        {
            return View();
        }




        public IActionResult koafor()
        {

            IEnumerable<koafor> Opject = _db.koafors;
            return View(Opject);

            
        }
        public IActionResult Createkoafor()
        {
            koafor doctor = new koafor(); 
            doctor.salons = _db.salons.ToList();
			return View(doctor);

		}

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Createkoafor(koafor obj)
        {

                _db.koafors.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "koafor created successfully";
                return RedirectToAction("koafor");
            
          
        }


        public IActionResult Editkoafor(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.koafors.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editkoafor(koafor obj)
        {

           
                _db.koafors.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "koafor updated successfully";
                return RedirectToAction("koafor");
           
        }

        public IActionResult Deletekoafor(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.koafors.Find(id);
            
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Deletekoafor")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOSTkoafor(int? id)
        {
            var obj = _db.koafors.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.koafors.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "koafor deleted successfully";
            return RedirectToAction("koafor");

        }



    }
}
