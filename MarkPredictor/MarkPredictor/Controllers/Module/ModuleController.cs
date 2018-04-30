using AutoMapper;
using MarkPredictor.Common;
using MarkPredictor.Dto;
using MarkPredictor.Shared.Models;
using System.Threading.Tasks;

namespace MarkPredictor.Controllers.Module
{
    public class ModuleController : IModuleController
    {
        private readonly HttpClient httpClient;

        public ModuleController()
        {
            httpClient = InstanceFactory.GetHttpClientInstance();
        }

        public async Task<ModuleDto> AddModule(ModuleDto moduleDto)
        {
            return await httpClient.AddModule(moduleDto);
        }
    }
}
