using MarkPredictor.Dto;
using MarkPredictor.Common;
using AutoMapper;
using System.Threading.Tasks;

namespace MarkPredictor.Controllers.Level
{
    public class LevelController : ILevelController
    {
        private readonly HttpClient httpClient;

        public LevelController()
        {
            httpClient = InstanceFactory.GetHttpClientInstance();
        }


        public async Task<LevelDto> GetLevelDetails(long levelId, long courseId)
        {
            var level = await httpClient.GetLevel(levelId, courseId);
            return level;
        }

        public async Task<LevelDto> Save(LevelDto levelDto)
        {
            var level = await httpClient.UpdateLevel(levelDto);
            return level;
        }
    }
}
