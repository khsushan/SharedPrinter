using System;
using System.Collections.Generic;
using System.Text;

namespace MarkPredictor.Shared.Entites
{
    public class Course
    {
        public long Id { get; set; }

        public long Name { get; set; }

        public ICollection<Module> Modules { get; set; }

    }
}
