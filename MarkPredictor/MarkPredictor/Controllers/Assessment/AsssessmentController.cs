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
        private readonly HttpClient httpClient;

        public AsssessmentController()
        {
            httpClient = InstanceFactory.GetHttpClientInstance();
        }

        public async Task<AssessmentDto> AddAssesment(AssessmentDto assigmentDto)
        {
            return await httpClient.AddAssessment(assigmentDto);
        }
    }
}
