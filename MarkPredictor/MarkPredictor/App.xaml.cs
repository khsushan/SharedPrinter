using Autofac;
using MarkPredictor.Common;
using MarkPredictor.Controllers.Module;
using MarkPredictor.Shared;
using MarkPredictor.Shared.Models;
using System.Windows;

namespace MarkPredictor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var builder = new ContainerBuilder();
            BuildupContainer(builder);
            InstanceFactory.Container = builder.Build();
            MainWindow mainWindows = new MainWindow();
            mainWindows.Show();
        }

        private void BuildupContainer(ContainerBuilder builder)
        {
            builder.RegisterType<MarkPredictorDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<ModuleModel>();
            builder.RegisterType<ModuleController>().As<IModuleController>().InstancePerLifetimeScope();
        }   
    }
}
