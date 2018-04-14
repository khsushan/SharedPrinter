using System;
using System.Collections.Generic;
using System.Text;

namespace MarkPredictor.Shared.Entites
{
    public class ModuleLevel
    {
        public long LevelId { get; set; }

        public long CourseId { get; set; }

        public Level Level { get; set; }

        public Course Course { get; set; }

    }
}
