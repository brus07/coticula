using System;
using System.Data.Entity;
using Coticula.Web.Models;

namespace Coticula.Web.Helpers
{
    public class CoticulaDbInitializer : DropCreateDatabaseIfModelChanges<CoticulaDbContext>
    {
        protected override void Seed(CoticulaDbContext context)
        {
            base.Seed(context);

            Solution sol1 = new Solution
            {
                Answer = "begin end.",
                DateTime = DateTime.Now,
                Language = new Language { Name = "Pascal" },
            };
            Result res1 = new Result
            {
                Verdict = new Verdict { Name = "In queue" }
            };
            sol1.Result = res1;
            res1.Solution = sol1;

            context.Solutions.Add(sol1);
            context.Results.Add(res1);

            int a = context.SaveChanges();
        }
    }
}