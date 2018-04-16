using System.Collections.Generic;

namespace MarkPredictor.Shared.Entites
{
    public class Module
    {
        public long Id { get; set; }

        public string ModuleName { get; set; }

        public long LevelId { get; set; }

        public Level Level { get; set; }

        public long CourseId { get; set; }

        public double Credit { get; set; }

        public Course Course { get; set; }

        public ICollection<Assessment> Assessments { get; set; }
    }
}
