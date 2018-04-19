using MarkPredictor.Dto;

namespace MarkPredictor.Controllers.Level
{
    public interface ILevelController
    {
        LevelDto GetLevelDetails(long levelId);

        LevelDto Save(LevelDto levelDto);
    }
}
