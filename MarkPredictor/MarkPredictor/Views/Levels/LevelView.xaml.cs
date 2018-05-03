using MarkPredictor.Common;
using MarkPredictor.Controllers.Level;
using MarkPredictor.Dto;
using MarkPredictor.MessageBus.Event;
using MarkPredictor.Views.Module;
using Prism.Events;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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
             LoadLevelData(_levelDto.Id);
            CalculateLevelAverage(_levelDto.Id);
            loadModuleViews();
            

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

        /// <summary>
        /// Load the level data
        /// </summary>
        /// <param name="levelId"></param>
        private void LoadLevelData(long levelId)
        {
            if (levelId == _levelDto.Id && _levelDto.Modules != null )
            {
                levelContentView.Children.Capacity = _levelDto.Modules.Count;
                levelContentView.Children.Clear();
            }         
        }

     

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Calculate the level average 
        /// </summary>
        /// <param name="levelId"> level id</param>
        private void CalculateLevelAverage(long levelId)
        {
            if (levelId == _levelDto.Id && _levelDto.Modules != null)
            {
                var average = 0.0;
                double creditTotal = _levelDto.Modules.Sum(item => item.Credit);

                for (int i =0; i <  _levelDto.Modules.Count; i++)
                {
                    var module =_levelDto.Modules[i];
                    module.ModuleAverage = AverageCalculator.CalculateModuleAverage(module);
                    average += module.ModuleAverage * module.Credit / creditTotal;
                }

                LevelAverage = Double.Parse(average.ToString("n2"));
                _levelDto.Average = Double.Parse(average.ToString("n2"));
                _eventAggregator.GetEvent<SummaryCalculateEvent>().Publish();
            }

            
        }

        /// <summary>
        /// Module mark change event method
        /// </summary>
        /// <param name="id"> level id</param>
        private void ModuleMarkChangeEvent(long id)
        {
            CalculateLevelAverage(id);
        }


        /// <summary>
        /// Load module views related to level
        /// </summary>
        private void loadModuleViews()
        {
            if (_levelDto.Modules != null)
            {
                foreach (var moduleDto in _levelDto.Modules)
                {
                    levelContentView.Children.Add(new ModuleView(moduleDto));
                }
            }
           
        }

        /// <summary>
        /// This method will called when new event added 
        /// </summary>
        /// <param name="moduleDto"></param>
        public void ModuleAddEvent(ModuleDto moduleDto)
        {
            if (moduleDto.LevelId == _levelDto.Id)
            {
                levelContentView.Children.Add(new ModuleView(moduleDto));
                _levelDto.Modules.Add(moduleDto);
                CalculateLevelAverage(moduleDto.LevelId);
            }
            
        }

        private async void saveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                await SaveLevelDetails();
                MessageBox.Show("Level details sucessfully saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public async Task SaveLevelDetails()
        {
            await _levelController.Save(_levelDto);

        }
    }
}
