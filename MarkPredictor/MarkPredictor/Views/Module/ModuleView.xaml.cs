﻿using MarkPredictor.Common;
using MarkPredictor.Dto;
using MarkPredictor.MessageBus.Event;
using MarkPredictor.Views.Assessment;
using Prism.Events;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MarkPredictor.Views.Module
{
    /// <summary>
    /// Interaction logic for ModuleView.xaml
    /// </summary>
    public partial class ModuleView : UserControl, INotifyPropertyChanged
    {
        private ModuleDto _moduleDto;
        private readonly IEventAggregator eventAggregator;

        public event PropertyChangedEventHandler PropertyChanged;
        private ICollection<AssessmentDto> _assessments;
        private double _moduleAverage;

        public ModuleView(ModuleDto moduleDto)
        {
            DataContext = this;
            InitializeComponent();           
            _moduleDto = moduleDto;
            moduleNameLable.Content = moduleDto.ModuleName;
            AssessmentList = _moduleDto.Assessments;
            eventAggregator = InstanceFactory.GetEventAggregatorInstance();
            eventAggregator.GetEvent<AssessmentLoadEvent>().Subscribe(ReloadAssessment);
            assessmentList.CellEditEnding += assementList_CellEditEnding;
            ModuleAverage = _moduleDto.ModuleAverage;
            modduleCreditLabel.Content = moduleDto.Credit;

        }

        private void addAssementBtn_Click(object sender, RoutedEventArgs e)
        {
            AddAssesmentView addAssesmentView = new AddAssesmentView(_moduleDto.Id);
            addAssesmentView.ShowDialog();
        }

        private void ReloadAssessment(AssessmentDto assessmentDto)
        {
            if (assessmentDto.ModuleId == _moduleDto.Id)
            {
                _moduleDto.Assessments.Add(assessmentDto);
                AssessmentList = _moduleDto.Assessments;
            }          
        }



        public ICollection<AssessmentDto> AssessmentList
        {
            get { return _assessments; }
            set
            {
                _assessments = value;
                OnPropertyChanged("AssessmentList");
            }
        }

        public double ModuleAverage
        {
            get { return _moduleAverage; }
            set
            {
                _moduleAverage = value;
                OnPropertyChanged("ModuleAverage");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void assementList_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var column = e.Column as DataGridBoundColumn;
                if (column != null)
                {
                    var bindingPath = (column.Binding as Binding).Path.Path;
                    if (bindingPath == "Mark")
                    {
                        int rowIndex = e.Row.GetIndex();
                        var el = e.EditingElement as TextBox;
                        try
                        {
                            _moduleDto.Assessments[rowIndex].Mark = double.Parse(el.Text);
                            CalculateModuleAverage();
                        }
                        catch (System.FormatException)
                        {
                            el.Text = "0";
                        }
                    }
                }
            }
        }

        private void CalculateModuleAverage()
        {
            ModuleAverage = AverageCalculator.CalculateModuleAverage(_moduleDto);
            eventAggregator.GetEvent<LevelMarkChangeEvent>().Publish(_moduleDto.LevelId);
        }

    }
}
