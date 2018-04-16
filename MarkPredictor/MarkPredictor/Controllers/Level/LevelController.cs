using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
