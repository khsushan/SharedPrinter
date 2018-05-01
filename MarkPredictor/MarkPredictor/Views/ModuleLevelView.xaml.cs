using MarkPredictor.Views.Module;
using System.Windows;
using System.Windows.Controls;

namespace MarkPredictor.Views
{
    /// <summary>
    /// Interaction logic for ModuleLevelView.xaml
    /// </summary>
    public partial class ModuleLevelView : UserControl
    {
        private long _courseId;
        public ModuleLevelView(long courseId)
        {
            InitializeComponent();
            _courseId = courseId;
        }

        private void Level4Button_Click(object sender, RoutedEventArgs e)
        {
            AddModuleView addModuleView = new AddModuleView(_courseId,1);
            addModuleView.ShowDialog();
        }

        private void level5Button_Click(object sender, RoutedEventArgs e)
        {
            AddModuleView addModuleView = new AddModuleView(_courseId, 2);
            addModuleView.ShowDialog();
        }

        private void level6Button_Click(object sender, RoutedEventArgs e)
        {
            AddModuleView addModuleView = new AddModuleView(_courseId, 3);
            addModuleView.ShowDialog();
        }
    }
}
