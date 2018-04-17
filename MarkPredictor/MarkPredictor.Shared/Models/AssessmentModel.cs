using MarkPredictor.Shared.Entites;
using MarkPredictor.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkPredictor.Shared.Models
{
    public class AssessmentModel
    {
        private MarkPredictorDbContext _markPredictorDbContext;

        public long Id { get; set; }

        public string Name { get; set; }

        public double Weight { get; set; }

        public long ModuleId { get; set; }

        public double Mark { get; set; }

        public AssessmentType AssessmentType { get; set; }

        public AssessmentModel(MarkPredictorDbContext markPredictorDbContext)
        {
            _markPredictorDbContext = markPredictorDbContext;
        }

        public int AddAssessment(Assessment assessment)
        {
            _markPredictorDbContext.Assessment.Add(assessment);
            return _markPredictorDbContext.SaveChanges();
        }



    }
}
