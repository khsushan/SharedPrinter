using MarkPredictor.Shared.Entites;
using System.Data.Entity;

namespace MarkPredictor.Shared
{
    public class MarkPredictorDbContext : DbContext
    {

        public DbSet<Course> Course { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<Level> Level { get; set; }

        public DbSet<Module> Module { get; set; }

        public DbSet<Assessment> Assessment { get; set; }

        public DbSet<ModuleLevel> ModuleLevel { get; set; }

        public MarkPredictorDbContext() : base("name=MarkPeredictorConnectionString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModuleLevel>().HasKey(ml =>  new {ml.LevelId, ml.CourseId });
        }
    }
}
