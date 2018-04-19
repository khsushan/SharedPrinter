using MarkPredictor.Common;
using MarkPredictor.Controllers.Level;
using MarkPredictor.Dto;
using MarkPredictor.MessageBus.Event;
using MarkPredictor.Views.Module;
using Prism.Events;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;

namespace MarkPredictor.Views.Levels
{
    /// <summary>
    /// Interaction logic for Level4.xaml
    /// </summary>
    public partial class LevelView : UserControl, INotifyPropertyChanged
    {
        private readonly IEventAggregator _eventAggregator;
        private double _levelAverage;
        private LevelDto _levelDto;
        private LevelController _levelController;
        public event PropertyChangedEventHandler PropertyChanged;

        public LevelView(LevelDto levelDto)
        {
            DataContext = this;
            _eventAggregator = InstanceFactory.GetEventAggregatorInstance();
            _eventAggregator.GetEvent<ModuleLoadEvent>().Subscribe(ModuleAddEvent);
            _eventAggregator.GetEvent<LevelMarkChangeEvent>().Subscribe(ModuleMarkChangeEvent);
            _levelController = new LevelController();
            LevelAverage = 0;
            InitializeComponent();
            _levelDto = levelDto;
             LoadLevel4Data(_levelDto.Id);
            CalculateLevelAverage(_levelDto.Id);
            loadModuleViews();
            

        }

        private void LoadLevel4Data(long levelId)
        {
            if (levelId == _levelDto.Id)
            {
                levelContentView.Children.Capacity = _levelDto.Modules.Count;
                levelContentView.Children.Clear();
            }         
        }

        public double LevelAverage
        {
            get { return _levelAverage; }
            set
            {
                _levelAverage = value;
                OnPropertyChanged("LevelAverage");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CalculateLevelAverage(long levelId)
        {
            if (levelId == _levelDto.Id)
            {
                var average = 0.0;
                double creditTotal = _levelDto.Modules.Sum(item => item.Credit);

                for (int i =0; i <  _levelDto.Modules.Count; i++)
                {
                    var module =_levelDto.Modules[i];
                    module.ModuleAverage = AverageCalculator.CalculateModuleAverage(module);
                    average += module.ModuleAverage * module.Credit / creditTotal;
                }

                LevelAverage = average;
                _levelDto.Average = average;  
            }

            _eventAggregator.GetEvent<SummaryCalculateEvent>().Publish();
        }

        private void ModuleMarkChangeEvent(long id)
        {
            CalculateLevelAverage(id);
        }


        private void loadModuleViews()
        {
            foreach (var moduleDto in _levelDto.Modules)
            {
                levelContentView.Children.Add(new ModuleView(moduleDto));
            }
        }

        public void ModuleAddEvent(ModuleDto moduleDto)
        {
            if (moduleDto.LevelId == _levelDto.Id)
            {
                levelContentView.Children.Add(new ModuleView(moduleDto));
                _levelDto.Modules.Add(moduleDto);
                CalculateLevelAverage(moduleDto.LevelId);
            }
            
        }

        private void saveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _levelController.Save(_levelDto);
        }
    }
}
