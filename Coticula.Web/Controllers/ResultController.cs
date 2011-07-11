using System.Data;
using System.Web.Mvc;
using Coticula.Web.Models;

namespace Coticula.Web.Controllers
{ 
    public class ResultController : Controller
    {
        private readonly CoticulaDbContext _db = new CoticulaDbContext();

        //
        // POST: /Result.json

        [HttpPost]
        public ActionResult Edit(DTO.Result result, string format)
        {
            if (format != "json")
                return null;

            if (ModelState.IsValid)
            {
                var res = new Result {Id = result.Id, VerdictId = result.VerdictId};
                _db.Entry(res).State = EntityState.Modified;
                _db.SaveChanges();
                //TODO:
                //return RedirectToAction("Index");
                return null;
            }
            //TODO:
            //ViewBag.VerdictId = new SelectList(db.Verdicts, "Id", "Name", result.VerdictId);
            //return View(result);
            return null;
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}