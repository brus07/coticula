using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Coticula.Web.Models;

namespace Coticula.Web.Controllers
{ 
    public class SolutionController : Controller
    {
        private readonly CoticulaDbContext _db = new CoticulaDbContext();

        //
        // GET: /Solution/

        public ViewResult Index()
        {
            var results = _db.Results.Include(r => r.Verdict).Include(r=>r.Solution.Language);
            return View(results.ToList());
        }

        //
        // GET: /Solution/Details/5

        public ViewResult Details(int id)
        {
            var result = _db.Results.Include(r => r.Solution.Language).Single(r => r.Id == id);
            return View(result);
        }
        
        //
        // GET: /Solution/Edit/5
 
        public ActionResult Edit(int id)
        {
            var result = _db.Results.Find(id);
            ViewBag.VerdictId = new SelectList(_db.Verdicts, "Id", "Name", result.VerdictId);
            return View(result);
        }

        //
        // POST: /Solution/Edit/5

        [HttpPost]
        public ActionResult Edit(Result result)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(result).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VerdictId = new SelectList(_db.Verdicts, "Id", "Name", result.VerdictId);
            return View(result);
        }

        //
        // GET: /Solution/Delete/5
 
        public ActionResult Delete(int id)
        {
            var result = _db.Results.Find(id);
            return View(result);
        }

        //
        // POST: /Solution/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            var result = _db.Results.Find(id);
            _db.Results.Remove(result);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}