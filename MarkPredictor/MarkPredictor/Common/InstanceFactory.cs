using Autofac;
using Autofac.Core;
using MarkPredictor.Controllers.Module;
using MarkPredictor.Shared.Models;
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

        public static IModuleController GetModulControllerInstance()
        {
            return Container.Resolve<IModuleController>();
        }
    }
}
