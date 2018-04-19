using MarkPredictor.Dto;
using MarkPredictor.Common;
using AutoMapper;

namespace MarkPredictor.Controllers.Level
{
    public class LevelController : ILevelController
    {


        public LevelDto GetLevelDetails(long levelId)
        {
            var levelModule = InstanceFactory.GetLevelModelInstance();
            levelModule.Id = levelId;
            return Mapper.Map<LevelDto>(levelModule.GetLevel());
        }

        public async System.Threading.Tasks.Task<LevelDto> Save(LevelDto levelDto)
        {
            var levelModule = InstanceFactory.GetLevelModelInstance();
            var level = await levelModule.SaveLevel(Mapper.Map<Shared.Entites.Level>(levelDto));
            return Mapper.Map<LevelDto>(level);
        }
    }
}
