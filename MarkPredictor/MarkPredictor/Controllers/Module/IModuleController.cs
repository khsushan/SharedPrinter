using MarkPredictor.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkPredictor.Controllers.Module
{
    public interface IModuleController
    {
        Task<ModuleDto> AddModule(ModuleDto moduleDto);
    }
}
