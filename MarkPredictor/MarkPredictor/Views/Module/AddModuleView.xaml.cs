using MarkPredictor.Common;
using MarkPredictor.Controllers.Module;
using MarkPredictor.Dto;
using MarkPredictor.MessageBus.Event;
using Prism.Events;
using System;
using System.Windows;

namespace MarkPredictor.Views.Module
{
    /// <summary>
    /// Interaction logic for AddModuleView.xaml
    /// </summary>
    public partial class AddModuleView : Window
    {
        private long _levelId;
        private long _courseId;
        private IModuleController _moduleController;
        private readonly IEventAggregator _eventAggregator;

        public AddModuleView()
        {
            InitializeComponent();
            _moduleController = InstanceFactory.GetModulControllerInstance();
            _eventAggregator = InstanceFactory.GetEventAggregatorInstance();
        }

        public AddModuleView(long courseId, long levelId) : this()
        {
            _courseId = courseId;
            _levelId = levelId;
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            var credit = double.Parse(moduleCreditText.Text);
            if (moduleNameText.Text.Trim() != string.Empty && credit > 0)
            {
                try
                {
                    ModuleDto moduleDto = new ModuleDto
                    {
                        ModuleName = moduleNameText.Text,
                        CourseId = _courseId,
                        LevelId = _levelId,
                        Credit = credit
                    };
                    moduleDto = _moduleController.AddModule(moduleDto);
                    moduleNameText.Text = string.Empty;
                    moduleCreditText.Text = "0";
                    _eventAggregator.GetEvent<ModuleLoadEvent>().Publish(moduleDto);
                    MessageBox.Show("Module details saved successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
        }
    }
}
