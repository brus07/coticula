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

            var pascal = new Language { Name = "Pascal" };
            var cpp = new Language { Name = "C++" };
            context.Languages.Add(pascal);
            context.Languages.Add(cpp);

            var inQueue = new Verdict { Id = 1, Name = "In queue" };
            var accepted = new Verdict { Id = 2, Name = "Accepted" };
            context.Verdicts.Add(inQueue);
            context.Verdicts.Add(accepted);

            var problem = new Problem {Id = 1, Name = "First problem", Description = " Very big description of problem"};
            context.Problems.Add(problem);

            var sol1 = new Solution
            {
                Answer = "begin end.",
                DateTime = DateTime.Now,
                Language = pascal,
                Problem =  problem
            };
            var res1 = new Result
                           {
                               Verdict = accepted,
                               Solution = sol1
                           };

            var sol2 = new Solution
            {
                Answer = "begin end.",
                DateTime = DateTime.Now,
                Language = cpp,
                Problem = problem
            };
            var res2 = new Result
                           {
                               Verdict = inQueue,
                               Solution = sol2
                           };

            context.Solutions.Add(sol1);
            context.Results.Add(res1);
            context.Solutions.Add(sol2);
            context.Results.Add(res2);

            context.SaveChanges();
        }
    }
}