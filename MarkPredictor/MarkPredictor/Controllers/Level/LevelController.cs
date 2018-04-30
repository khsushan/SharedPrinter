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


        public async Task<LevelDto> GetLevelDetails(long levelId)
        {
            var level = await httpClient.GetLevel(levelId);
            return level;
        }

        public async Task<LevelDto> Save(LevelDto levelDto)
        {
            var level = await httpClient.UpdateLevel(levelDto);
            return level;
        }
    }
}
