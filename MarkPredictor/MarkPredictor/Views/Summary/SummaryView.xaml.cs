using MarkPredictor.Common;
using MarkPredictor.Dto;
using MarkPredictor.MessageBus.Event;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MarkPredictor.Views.Summary
{
    /// <summary>
    /// Interaction logic for SummaryView.xaml
    /// </summary>
    public partial class SummaryView : UserControl, INotifyPropertyChanged
    {
        private LevelDto _level5Dto;
        private LevelDto _level6Dto;
        private double _average;
        private string _grade;
        private const string FirstClass = "1st Class Honours (1)";
        private const string SecondUpperClass = "2nd Class Honours Upper Division (2:i) ";
        private const string SecondLowerClass = "2nd Class Honours Lower Division (2:ii) ";
        private const string ThirdClass = "3rd Class Honours (3) ";
        private const string Fail = "Fail";
        private readonly IEventAggregator _eventAggregator;

        public SummaryView(LevelDto level5Dto, LevelDto level6Dto)
        {
            DataContext = this;
            _level5Dto = level5Dto;
            _level6Dto = level6Dto;
            InitializeComponent();
            _eventAggregator = InstanceFactory.GetEventAggregatorInstance();
            _eventAggregator.GetEvent<SummaryCalculateEvent>().Subscribe(CalculateCourseOutcome);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public double Average
        {
            get { return _average; }
            set
            {
                _average = value;
                OnPropertyChanged("Average");
            }
        }

        public string Grade
        {
            get { return _grade; }
            set
            {
                _grade = value;
                OnPropertyChanged("Grade");
            }
        }

        private void CalculateCourseOutcome()
        {
            double overallAvg = _level5Dto.Average * 1 / 3 + _level6Dto.Average * 2 / 3;
            Average = Double.Parse(overallAvg.ToString("n2"));
            GradeCalculation(overallAvg);
        }

        private void GradeCalculation(double overallAvg)
        {
            if (overallAvg >= 70)
            {
                Grade = FirstClass;
            }
            else if ( 60 <= overallAvg && overallAvg < 70)
            {
                Grade = SecondUpperClass;
            }
            else if (50 <= overallAvg && overallAvg < 60)
            {
                Grade = SecondLowerClass;
            }
            else if (40 <= overallAvg && overallAvg < 50)
            {
                Grade = ThirdClass;
            }
            else
            {
                Grade = Fail;
            }
        }


        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
