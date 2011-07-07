using System.Data.Entity;

namespace Coticula.Web.Models
{
    public class CoticulaDbContext: DbContext
    {
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Verdict> Verdicts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Result>().HasRequired(x => x.Solution).WithMany().WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}