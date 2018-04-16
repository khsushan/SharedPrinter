using AutoMapper;
using MarkPredictor.Dto;
using MarkPredictor.Shared.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkPredictor.Common
{
    public static class AutoMapper
    {
        private static bool _isInitialized;
        public static void Initialize()
        {
            if (!_isInitialized)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Module, ModuleDto>();
                    cfg.CreateMap<Assessment, AssessmentDto>();
                    cfg.CreateMap<Level, LevelDto>();
                });
                _isInitialized = true;
            }
        }
    }
}
