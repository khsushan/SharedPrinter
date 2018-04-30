using MarkPredictor.Common;
using MarkPredictor.Controllers.Assessment;
using MarkPredictor.Dto;
using MarkPredictor.MessageBus.Event;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace MarkPredictor.Views.Assessment
{
    /// <summary>
    /// Interaction logic for AddAssigmentView.xaml
    /// </summary>
    public partial class AddAssesmentView : System.Windows.Window, INotifyPropertyChanged
    {
        private long _moduleId = 0;
        private IList<string> _assigmentTypes;
        public string _selectedAssigmentType;
        public event PropertyChangedEventHandler PropertyChanged;
        private IAssessmentController _assessmentController;
        private readonly IEventAggregator _eventAggregator;
        private double _sumofCurrentAssessmentWeight;


        public AddAssesmentView()
        {
            _assigmentTypes = new List<string>();
            _assigmentTypes.Add("Exam");
            _assigmentTypes.Add("Courese Work");
            _assessmentController = InstanceFactory.GetAssessmentControllerInstance();
            _eventAggregator = InstanceFactory.GetEventAggregatorInstance();
            _selectedAssigmentType = _assigmentTypes[0];
            AssigmentTypes = _assigmentTypes;
            this.DataContext = this;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public AddAssesmentView(long moduleId, double sumofCurrentAssessmentWeight) : this()
        {
            _moduleId = moduleId;
            _sumofCurrentAssessmentWeight = sumofCurrentAssessmentWeight;
        }

        public IList<string> AssigmentTypes
        {
            get { return _assigmentTypes; }
            set
            {
                _assigmentTypes = value;
                OnPropertyChanged("AssigmentTypes");
            }
        }

        public string SelectedAssigmentType
        {
            get { return _selectedAssigmentType; }
            set
            {
                _selectedAssigmentType = value;
                OnPropertyChanged("SelectedAssigmentType");
            }
        }



        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void okBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string assigmentName = assigmentNameText.Text;
            double assigmentPrecentage = double.Parse(assigmentPrecentageText.Text);

            if ((assigmentPrecentage + _sumofCurrentAssessmentWeight) > 100)
            {
                MessageBox.Show("Sorry sum of the assessment weight in module cannot be greater than 100");
            }
            else if (assigmentName.Trim() != string.Empty && assigmentPrecentage > 0)
            {
                try
                {
                    AssessmentDto assigmentDto = new AssessmentDto
                    {
                        Name = assigmentName,
                        Weight = assigmentPrecentage,
                        ModuleId = _moduleId
                    };

                    if (SelectedAssigmentType == "Exam")
                    {
                        assigmentDto.AssessmentType = Shared.Enum.AssessmentType.EXAM;
                    }
                    else
                    {
                        assigmentDto.AssessmentType = Shared.Enum.AssessmentType.CourseWork;
                    }

                    assigmentDto = await _assessmentController.AddAssesment(assigmentDto);
                    _eventAggregator.GetEvent<AssessmentLoadEvent>().Publish(assigmentDto);
                    assigmentNameText.Text = string.Empty;
                    assigmentPrecentageText.Text = "0";
                    SelectedAssigmentType = "Exam";
                    MessageBox.Show("Assessment saved successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Please provide valid inputs");
            }
        }

        private void assigmentPrecentageText_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 ||
                key >= 74 && key <= 83 || key == 2);
        }
    }
}
