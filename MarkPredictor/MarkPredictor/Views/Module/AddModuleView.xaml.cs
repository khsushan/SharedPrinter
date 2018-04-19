﻿using MarkPredictor.Common;
using MarkPredictor.Controllers.Module;
using MarkPredictor.Dto;
using MarkPredictor.MessageBus.Event;
using Prism.Events;
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
                ModuleDto moduleDto = new ModuleDto
                {
                    ModuleName = moduleNameText.Text,
                    CourseId = _courseId,
                    LevelId = _levelId,
                    Credit = credit
                };
                moduleDto = _moduleController.AddModule(moduleDto);
                moduleNameText.Text = string.Empty;
                _eventAggregator.GetEvent<ModuleLoadEvent>().Publish(moduleDto);
            }
        }
    }
}