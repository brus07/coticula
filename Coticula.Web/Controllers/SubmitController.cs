using System;
using System.Web.Mvc;
using Coticula.Web.Models;

namespace Coticula.Web.Controllers
{ 
    public class SubmitController : Controller
    {
        private readonly CoticulaDbContext _db = new CoticulaDbContext();

        //
        // GET: /Submit/

        public ViewResult Index()
        {
            ViewBag.LanguageId = new SelectList(_db.Languages, "Id", "Name", 1);
            ViewBag.ProblemId = new SelectList(_db.Problems, "Id", "Name", 1);
            Solution model = new Solution();
            model.DateTime = DateTime.Now;
            return View(model);
        }

        //
        // POST: /Submit/Index

        [HttpPost]
        public ActionResult Index(Solution solution)
        {
            if (ModelState.IsValid)
            {
                var result = new Result {Solution = solution};
                _db.Results.Add(result);
                _db.SaveChanges();
                return RedirectToAction("Index", "Solution");
            }

            ViewBag.LanguageId = new SelectList(_db.Languages, "Id", "Name", solution.LanguageId);
            return View(solution);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}