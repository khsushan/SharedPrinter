using MarkPredictor.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkPredictor.Shared.Entites
{
    public class Assessment
    {
        public long Id { get; set; }

        public AssessmentType  AssessmentType { get; set; }

        public string Name { get; set; }

        public double Weight { get; set; }

        public int Mark { get; set; }

        public long ModuleId { get; set; }

        public Module Module { get; set; }
    }
}
