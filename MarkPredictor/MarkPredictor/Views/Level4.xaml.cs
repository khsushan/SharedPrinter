using MarkPredictor.Common;
using MarkPredictor.Controllers.Level;
using MarkPredictor.Shared.MessageBus.Event;
using MarkPredictor.Views.Module;
using Prism.Events;
using System.Windows.Controls;

namespace MarkPredictor.Views
{
    /// <summary>
    /// Interaction logic for Level4.xaml
    /// </summary>
    public partial class Level4 : UserControl
    {
        private LevelController _levelController;
        private readonly IEventAggregator _eventAggregator;


        public Level4()
        {
            InitializeComponent();
            _levelController = new LevelController();
            LoadLevel4Data(string.Empty);
            _eventAggregator = InstanceFactory.GetEventAggregatorInstance();
            _eventAggregator.GetEvent<ModuleLoadEvent>().Subscribe(LoadLevel4Data);
            
        }

        private void LoadLevel4Data(string s)
        {
           var levelDto =  _levelController.GetLevelDetails(1);
            level4ContentView.Children.Capacity = levelDto.Modules.Count;
            level4ContentView.Children.Clear();
            foreach (var moduleDto in levelDto.Modules)
            {
                level4ContentView.Children.Add(new ModuleView(moduleDto));
            }
        }


    }
}
