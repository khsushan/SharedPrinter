using Autofac;
using Autofac.Core;
using MarkPredictor.Controllers.Assessment;
using MarkPredictor.Controllers.Module;
using MarkPredictor.Shared.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkPredictor.Common
{
    public class InstanceFactory
    {
        public static IContainer Container { get; set; }

        public static ModuleModel GetModuleModelInstance()
        {
            return Container.Resolve<ModuleModel>();
        }

        public static LevelModel GetLevelModelInstance()
        {
            return Container.Resolve<LevelModel>();
        }

        public static AssessmentModel GetAssessmentModelInstance()
        {
            return Container.Resolve<AssessmentModel>();
        }

        public static IModuleController GetModulControllerInstance()
        {
            return Container.Resolve<IModuleController>();
        }

        public static IAssessmentController GetAssessmentControllerInstance()
        {
            return Container.Resolve<IAssessmentController>();
        }

        public static IEventAggregator GetEventAggregatorInstance()
        {
            return Container.Resolve<IEventAggregator>();
        }
    }
}
