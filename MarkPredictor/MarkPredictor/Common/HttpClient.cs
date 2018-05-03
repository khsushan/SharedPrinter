using MarkPredictor.Dto;
using RestSharp;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace MarkPredictor.Common
{
    public class HttpClient
    {
        private readonly RestClient restClient;

        public HttpClient()
        {
            restClient = new RestClient();
            string url = ConfigurationSettings.AppSettings["ServerBaseUrl"].ToString();
            restClient.BaseUrl = new Uri(url);
        }



        public async Task<LevelDto> UpdateLevel(LevelDto level)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = @"levels/update";
            request.RequestFormat = DataFormat.Json;
            request.AddBody(level);
            var response = await restClient.ExecuteTaskAsync(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<LevelDto>(response.Content);
        }

        public async Task<AssessmentDto> AddAssessment(AssessmentDto assessment)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = @"assessments/add";
            request.RequestFormat = DataFormat.Json;
            request.AddBody(assessment);
            var response = await restClient.ExecuteTaskAsync(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<AssessmentDto>(response.Content);
        }

        public async Task<ModuleDto> AddModule(ModuleDto module)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = @"modules/add";
            request.RequestFormat = DataFormat.Json;
            request.AddBody(module);
            var response = await restClient.ExecuteTaskAsync(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ModuleDto>(response.Content);
        }

        public async Task<LevelDto> GetLevel(long levelId, long courseId)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = $"levels/{levelId}/course/{courseId}";
            request.RequestFormat = DataFormat.Json;
            var response = await restClient.ExecuteTaskAsync(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<LevelDto>(response.Content);
        }

        public async Task<StudentDto> Login(StudentDto studentDto)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = @"accounts/login";
            request.RequestFormat = DataFormat.Json;
            request.AddBody(studentDto);
            var response = await restClient.ExecuteTaskAsync(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<StudentDto>(response.Content);
        }
    }
}
