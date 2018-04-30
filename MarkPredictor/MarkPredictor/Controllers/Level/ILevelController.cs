using MarkPredictor.Dto;
using System.Threading.Tasks;

namespace MarkPredictor.Controllers.Level
{
    public interface ILevelController
    {
        Task<LevelDto> GetLevelDetails(long levelId, long courseId);

        Task<LevelDto> Save(LevelDto levelDto);
    }
}
