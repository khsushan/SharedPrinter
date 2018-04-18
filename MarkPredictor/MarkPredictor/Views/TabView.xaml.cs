using MarkPredictor.Controllers.Level;
using MarkPredictor.Dto;
using MarkPredictor.Views.Levels;
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

        public TabView()
        {
            InitializeComponent();
            _levelController = new LevelController();
            LoadLevelData();
         
        }

        private void LoadLevelData()
        {
            _level4Dto = _levelController.GetLevelDetails(1);
            Level4Tab.Content = new LevelView(_level4Dto);

            _level5Dto = _levelController.GetLevelDetails(2);
            Level5Tab.Content = new LevelView(_level5Dto);

            _level6Dto = _levelController.GetLevelDetails(3);
            Level6Tab.Content = new LevelView(_level6Dto);

        }
    }
}
