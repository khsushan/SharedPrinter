using Autofac;
using MarkPredictor.Common;
using MarkPredictor.Controllers.Assessment;
using MarkPredictor.Controllers.Module;
using MarkPredictor.Shared;
using MarkPredictor.Shared.Models;
using MarkPredictor.Views;
using Prism.Events;
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
            ConfigAutofac();
            Common.AutoMapper.Initialize();
            MainWindow mainWindows = new MainWindow();
            mainWindows.Show();
        }

        private void ConfigAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MarkPredictorDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<ModuleModel>();
            builder.RegisterType<LevelModel>();
            builder.RegisterType<AssessmentModel>();            
            builder.RegisterType<ModuleController>().As<IModuleController>().InstancePerLifetimeScope();
            builder.RegisterType<AsssessmentController>().As<IAssessmentController>().InstancePerLifetimeScope();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().InstancePerLifetimeScope();
            builder.RegisterType<HttpClient>();
            InstanceFactory.Container = builder.Build();
        }   
    }
}
