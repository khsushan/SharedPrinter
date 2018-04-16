using MarkPredictor.Controllers.Level;
using MarkPredictor.Views.Module;
using System.Windows.Controls;

namespace MarkPredictor.Views
{
    /// <summary>
    /// Interaction logic for Level4.xaml
    /// </summary>
    public partial class Level4 : UserControl
    {
        private LevelController _levelController;

        public Level4()
        {
            InitializeComponent();
            _levelController = new LevelController();
            LoadLevel4Data();
            
        }

        private void LoadLevel4Data()
        {
           var levelDto =  _levelController.GetLevelDetails(1);
            foreach (var moduleDto in levelDto.Modules)
            {
                level4ContentView.Children.Add(new ModuleView(moduleDto));
            }
        }
    }
}
