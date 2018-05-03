using MarkPredictor.Common;
using MarkPredictor.Controllers.Level;
using MarkPredictor.Dto;
using MarkPredictor.MessageBus.Event;
using MarkPredictor.Views.Levels;
using MarkPredictor.Views.Summary;
using Prism.Events;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace MarkPredictor.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TabView : Window
    {
        private LevelController _levelController;
        private LevelDto _level4Dto;
        private LevelDto _level5Dto;
        private LevelDto _level6Dto;
        private readonly IEventAggregator _eventAggregator;
        private LevelView _level4View;
        private LevelView _level5View;
        private LevelView _level6View;
        private long _courseId;


        public TabView(long courseId)
        {
            _eventAggregator = InstanceFactory.GetEventAggregatorInstance();
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _levelController = new LevelController();
            _courseId = courseId;
            Application.Current.Dispatcher.Invoke(new Action(async () => { await LoadTabs(); }));
            _eventAggregator.GetEvent<SummaryCalculateEvent>().Publish();
        }

        /// <summary>
        /// Load all tabs with data 
        /// </summary>
        /// <returns></returns>
        private async Task LoadTabs()
        {
            ModuleLevelTab.Content = new ModuleLevelView(_courseId);

            _level4Dto = await _levelController.GetLevelDetails(1, _courseId);
            _level4Dto = _level4Dto == null ? new LevelDto() : _level4Dto;
            _level4View = new LevelView(_level4Dto);
            Level4Tab.Content = _level4View;

            _level5Dto = await _levelController.GetLevelDetails(2, _courseId);
            _level5Dto = _level5Dto == null ? new LevelDto() : _level5Dto;
            _level5View = new LevelView(_level5Dto);
            Level5Tab.Content = _level5View;

            _level6Dto = await _levelController.GetLevelDetails(3, _courseId);
            _level6Dto = _level6Dto == null ? new LevelDto() : _level6Dto;
            _level6View = new LevelView(_level6Dto);
            Level6Tab.Content = _level6View;

            SummaryViewTab.Content = new SummaryView(_level5Dto, _level6Dto);

        }

        private async void exitButton_Click(object sender, RoutedEventArgs e)
        {
            await HandleSave();
            Application.Current.Windows[0].Close();
        }

        /// <summary>
        /// Handle save when user exit the system
        /// </summary>
        /// <returns></returns>
        private async Task HandleSave()
        {
            MessageBoxResult result = MessageBox.Show("Do you need to save the changes before exit", "Mark Predictor", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {

                await _level4View.SaveLevelDetails();
                await _level5View.SaveLevelDetails();
                await _level6View.SaveLevelDetails();
            }
        }

        private void SummaryViewTab_Loaded(object sender, RoutedEventArgs e)
        {
            _eventAggregator.GetEvent<SummaryCalculateEvent>().Publish();
        }
    }
}
