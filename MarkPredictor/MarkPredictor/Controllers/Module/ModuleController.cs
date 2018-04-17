using MarkPredictor.Dto;
using MarkPredictor.Shared.Models;

namespace MarkPredictor.Controllers.Module
{
    public class ModuleController : IModuleController
    {
        private ModuleModel _moduleModel;

        public ModuleController(ModuleModel moduleModel)
        {
            _moduleModel = moduleModel;
        }

        public int AddModule(ModuleDto moduleDto)
        {
            _moduleModel.ModuleName = moduleDto.ModuleName;
            _moduleModel.CourseId = moduleDto.CourseId;
            _moduleModel.LevelId = moduleDto.LevelId;
            _moduleModel.Credit = moduleDto.Credit;
            return _moduleModel.Save();
        }
    }
}
