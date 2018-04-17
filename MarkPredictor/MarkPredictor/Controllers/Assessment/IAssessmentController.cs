using MarkPredictor.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkPredictor.Controllers.Assessment
{
    public interface IAssessmentController
    {
        int AddAssesment(AssessmentDto assigmentDto);
    }
}
