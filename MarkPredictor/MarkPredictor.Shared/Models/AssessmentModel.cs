using MarkPredictor.Shared.Entites;
using MarkPredictor.Shared.Enum;

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

        public Assessment AddAssessment(Assessment assessment)
        {
            _markPredictorDbContext.Assessment.Add(assessment);
            _markPredictorDbContext.SaveChanges();
            _markPredictorDbContext.Entry(assessment).State = System.Data.Entity.EntityState.Detached;
            return assessment;
        }



    }
}
