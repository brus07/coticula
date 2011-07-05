using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Coticula.Web.Models;

namespace Coticula.Web.Controllers
{ 
    public class SolutionController : Controller
    {
        private CoticulaDbContext db = new CoticulaDbContext();

        //
        // GET: /Solution/

        public ViewResult Index()
        {
            var solutions = db.Solutions.Include(s => s.Language);
            return View(solutions.ToList());
        }

        //
        // GET: /Solution/Details/5

        public ViewResult Details(int id)
        {
            Solution solution = db.Solutions.Find(id);
            return View(solution);
        }
        
        //
        // GET: /Solution/Edit/5
 
        public ActionResult Edit(int id)
        {
            Solution solution = db.Solutions.Find(id);
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", solution.LanguageId);
            return View(solution);
        }

        //
        // POST: /Solution/Edit/5

        [HttpPost]
        public ActionResult Edit(Solution solution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", solution.LanguageId);
            return View(solution);
        }

        //
        // GET: /Solution/Delete/5
 
        public ActionResult Delete(int id)
        {
            Solution solution = db.Solutions.Find(id);
            return View(solution);
        }

        //
        // POST: /Solution/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Solution solution = db.Solutions.Find(id);
            db.Solutions.Remove(solution);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}