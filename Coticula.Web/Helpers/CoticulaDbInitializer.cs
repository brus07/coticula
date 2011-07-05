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

            Language pascal = new Language { Name = "Pascal" };
            Language cpp = new Language { Name = "C++" };
            context.Languages.Add(pascal);
            context.Languages.Add(cpp);

            Verdict inQueue = new Verdict { Id = 1, Name = "In queue" };
            Verdict accepted = new Verdict { Id = 2, Name = "Accepted" };
            context.Verdicts.Add(inQueue);
            context.Verdicts.Add(accepted);

            Solution sol1 = new Solution
            {
                Answer = "begin end.",
                DateTime = DateTime.Now,
                Language = pascal,
            };
            Result res1 = new Result
            {
                Verdict = accepted
            };
            sol1.Result = res1;
            res1.Solution = sol1;

            Solution sol2 = new Solution
            {
                Answer = "begin end.",
                DateTime = DateTime.Now,
                Language = cpp,
            };
            Result res2 = new Result
            {
                Verdict = inQueue
            };
            sol2.Result = res2;
            res2.Solution = sol2;

            context.Solutions.Add(sol1);
            context.Results.Add(res1);
            context.Solutions.Add(sol2);
            context.Results.Add(res2);

            context.SaveChanges();
        }
    }
}