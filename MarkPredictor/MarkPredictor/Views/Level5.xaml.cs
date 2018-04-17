using MarkPredictor.Common;
using MarkPredictor.Controllers.Level;
using MarkPredictor.Dto;
using MarkPredictor.MessageBus.Event;
using MarkPredictor.Views.Module;
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

namespace MarkPredictor.Views
{
    /// <summary>
    /// Interaction logic for Level5.xaml
    /// </summary>
    public partial class Level5 : UserControl, INotifyPropertyChanged
    {
        private LevelController _levelController;
        private readonly IEventAggregator _eventAggregator;
        private double _levelAverage;
        private LevelDto _levelDto;

        public event PropertyChangedEventHandler PropertyChanged;

        public Level5()
        {
            DataContext = this;
            InitializeComponent();
            _levelController = new LevelController();
            LoadLevelData(2);
            CalculateLevelAverage(2);
            loadModuleViews();
            _eventAggregator = InstanceFactory.GetEventAggregatorInstance();
            _eventAggregator.GetEvent<ModuleLoadEvent>().Subscribe(ModuleAddEvent);
            _eventAggregator.GetEvent<LevelMarkChangeEvent>().Subscribe(ModuleMarkChangeEvent);
        }

        private void LoadLevelData(long levelId)
        {
            if (levelId == 2)
            {
                _levelDto = _levelController.GetLevelDetails(levelId);
                level5ContentView.Children.Capacity = _levelDto.Modules.Count;
                level5ContentView.Children.Clear();
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
            if (levelId == 2)
            {
                var average = 0.0;
                double creditTotal = _levelDto.Modules.Sum(item => item.Credit);

                for (int i = 0; i < _levelDto.Modules.Count; i++)
                {
                    var module = _levelDto.Modules[i];
                    module.ModuleAverage = AverageCalculator.CalculateModuleAverage(module);
                    average += module.ModuleAverage * module.Credit / creditTotal;
                }

                LevelAverage = average;
            }
        }

        private void ModuleMarkChangeEvent(long id)
        {
            CalculateLevelAverage(id);
        }


        private void loadModuleViews()
        {
            foreach (var moduleDto in _levelDto.Modules)
            {
                level5ContentView.Children.Add(new ModuleView(moduleDto));
            }
        }

        public void ModuleAddEvent(ModuleDto moduleDto)
        {
            if (moduleDto.LevelId == 2)
            {
                level5ContentView.Children.Add(new ModuleView(moduleDto));
                _levelDto.Modules.Add(moduleDto);
                CalculateLevelAverage(moduleDto.LevelId);
            }

        }


    }
}
