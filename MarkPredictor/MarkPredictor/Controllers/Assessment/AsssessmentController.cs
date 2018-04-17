using AutoMapper;
using MarkPredictor.Common;
using MarkPredictor.Dto;
using MarkPredictor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkPredictor.Controllers.Assessment
{
    public class AsssessmentController : IAssessmentController
    {

        public int AddAssesment(AssessmentDto assigmentDto)
        {
            var assessmentModel = InstanceFactory.GetAssessmentModelInstance();
            return assessmentModel.AddAssessment(Mapper.Map<Shared.Entites.Assessment>(assigmentDto));
        }
    }
}
