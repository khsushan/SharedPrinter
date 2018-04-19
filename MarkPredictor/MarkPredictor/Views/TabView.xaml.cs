using MarkPredictor.Common;
using MarkPredictor.Controllers.Level;
using MarkPredictor.Dto;
using MarkPredictor.MessageBus.Event;
using MarkPredictor.Views.Levels;
using MarkPredictor.Views.Summary;
using Prism.Events;
using System.Windows;

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

        public TabView()
        {
            _eventAggregator = InstanceFactory.GetEventAggregatorInstance();
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _levelController = new LevelController();
            LoadTabs();
            

        }

        private void LoadTabs()
        {
            _level4Dto = _levelController.GetLevelDetails(1);
            Level4Tab.Content = new LevelView(_level4Dto);

            _level5Dto = _levelController.GetLevelDetails(2);
            Level5Tab.Content = new LevelView(_level5Dto);

            _level6Dto = _levelController.GetLevelDetails(3);
            Level6Tab.Content = new LevelView(_level6Dto);

            SummaryViewTab.Content = new SummaryView(_level5Dto, _level6Dto);

        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            HandleSave();
            Application.Current.Windows[0].Close();
        }

        private void HandleSave()
        {
            MessageBoxResult result = MessageBox.Show("Do you need to save the changes before exit", "Mark Predictor", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                _eventAggregator.GetEvent<SaveEvent>().Publish();

            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            HandleSave();
        }

        private void SummaryViewTab_Loaded(object sender, RoutedEventArgs e)
        {
            _eventAggregator.GetEvent<SummaryCalculateEvent>().Publish();
        }
    }
}
