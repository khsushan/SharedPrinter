using MarkPredictor.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkPredictor.Dto
{
    public class AssessmentDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public double Weight { get; set; }

        public long ModuleId { get; set; }

        public double Mark { get; set; }

        public AssessmentType AssessmentType { get; set; }
    }
}
