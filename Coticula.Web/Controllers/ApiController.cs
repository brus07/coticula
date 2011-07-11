using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Coticula.Web.Models;

namespace Coticula.Web.Controllers
{
    public class ApiController : Controller
    {
        private readonly CoticulaDbContext _db = new CoticulaDbContext();

        //
        // GET: /Api/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Api/Untested.json

        public ActionResult Untested(string format)
        {
            if (format != "json")
                return null;

            var untestedIdList = Models.Solution.UntestedId();
            return Json(untestedIdList, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Api/Solution/5.json

        public ActionResult Solution(int id, string format)
        {
            if (format != "json")
                return null;

            var result =_db.Results.Include(r => r.Solution.Language).Single(r => r.Id == id);

            var solution = new DTO.Solution
            {
                Id = result.Id,
                Answer = result.Solution.Answer,
                LanguageId = result.Solution.LanguageId
            };

            return Json(solution, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Api/Result.json

        [HttpPost]
        public ActionResult Result(DTO.Result result, string format)
        {
            if (format != "json")
                return null;

            if (ModelState.IsValid)
            {
                var res = new Result {Id = result.Id, VerdictId = result.VerdictId};
                try
                {
                    _db.Entry(res).State = EntityState.Modified;
                    _db.SaveChanges();
                    return Json("ok");
                }
                catch
                {

                }
            }
            return Json("error");
        }

    }
}
