using System.Collections.ObjectModel;

namespace MarkPredictor.Dto
{
    public class ModuleDto
    {
        public long Id { get; set; }

        public string ModuleName { get; set; }

        public long LevelId { get; set; }

        public long CourseId { get; set; }

        public double Credit { get; set; }

        public ObservableCollection<AssessmentDto> Assessments { get; set; }
    }
}
