using MarkPredictor.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkPredictor.Common
{
    public class AverageCalculator
    {
        public static  double CalculateModuleAverage(ModuleDto moduleDto)
        {
            var average = 0.0;
            foreach (var assessment in moduleDto.Assessments)
            {
                average += assessment.Mark * (assessment.Weight / 100.0);
            }

           return average;
        }
    }
}
