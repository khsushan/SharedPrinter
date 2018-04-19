using MarkPredictor.Dto;

namespace MarkPredictor.Controllers.Level
{
    public interface ILevelController
    {
        LevelDto GetLevelDetails(long levelId);

        System.Threading.Tasks.Task<LevelDto> Save(LevelDto levelDto);
    }
}
