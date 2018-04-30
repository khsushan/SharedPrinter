using MarkPredictor.Common;
using MarkPredictor.Controllers.Level;
using MarkPredictor.Dto;
using MarkPredictor.MessageBus.Event;
using MarkPredictor.Views.Levels;
using MarkPredictor.Views.Summary;
using Prism.Events;
using System;
using System.Threading.Tasks;
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
        private LevelView _level4View;
        private LevelView _level5View;
        private LevelView _level6View;


        public TabView()
        {
            _eventAggregator = InstanceFactory.GetEventAggregatorInstance();
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _levelController = new LevelController();
            Application.Current.Dispatcher.Invoke(new Action(async () => { await LoadTabs(); }));


        }

        private async Task LoadTabs()
        {
            _level4Dto = await _levelController.GetLevelDetails(1);
            _level4View = new LevelView(_level4Dto);
            Level4Tab.Content = _level4View;

            _level5Dto = await _levelController.GetLevelDetails(2);
            _level5View = new LevelView(_level5Dto);
            Level5Tab.Content = _level5View;

            _level6Dto = await _levelController.GetLevelDetails(3);
            _level6View = new LevelView(_level6Dto);
            Level6Tab.Content = _level6View;

            SummaryViewTab.Content = new SummaryView(_level5Dto, _level6Dto);

        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {

            Application.Current.Windows[0].Close();
        }

        private async void HandleSave()
        {
            MessageBoxResult result = MessageBox.Show("Do you need to save the changes before exit", "Mark Predictor", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                await _level4View.SaveLevelDetails();
                await _level5View.SaveLevelDetails();
                await _level6View.SaveLevelDetails();

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
