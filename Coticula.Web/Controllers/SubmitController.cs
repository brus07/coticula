using System.Web.Mvc;
using Coticula.Web.Models;

namespace Coticula.Web.Controllers
{ 
    public class SubmitController : Controller
    {
        private CoticulaDbContext db = new CoticulaDbContext();

        //
        // GET: /Submit/

        public ViewResult Index()
        {
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name");
            return View();
        }

        //
        // POST: /Submit/Index

        [HttpPost]
        public ActionResult Index(Solution solution)
        {
            if (ModelState.IsValid)
            {
                db.Solutions.Add(solution);
                db.SaveChanges();
                return RedirectToAction("Index", "Solution");  
            }

            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", solution.LanguageId);
            return View(solution);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}