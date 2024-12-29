using B201210597.Models.Domain;
using B201210597.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace B201210597.Controllers
{
    [Authorize(Roles = "admin")]
    public class KlinikController : Controller
    {
        private readonly DatabaseContext _db;

        public KlinikController(DatabaseContext db)
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




        public IActionResult Index()
        {

            IEnumerable<salon> Opject = _db.salons;
            return View(Opject);


        }
        public IActionResult Create()
        {
            salon X = new salon();
            X.Departments = _db.Departments.ToList();
            return View(X);

        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(salon obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}
            //   if (ModelState.IsValid)

            _db.salons.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "salon Eklendi";
            return RedirectToAction("Index");


        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.salons.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(salon obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}

            _db.salons.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Klinik updated successfully";
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.salons.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.salons.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.salons.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "salon deleted successfully";
            return RedirectToAction("Index");

        }



    }
}
