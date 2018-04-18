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
        public ModuleLevelView()
        {
            InitializeComponent();
        }

        private void Level4Button_Click(object sender, RoutedEventArgs e)
        {
            AddModuleView addModuleView = new AddModuleView(1,1);
            addModuleView.ShowDialog();
        }

        private void level5Button_Click(object sender, RoutedEventArgs e)
        {
            AddModuleView addModuleView = new AddModuleView(1, 2);
            addModuleView.ShowDialog();
        }

        private void level6Button_Click(object sender, RoutedEventArgs e)
        {
            AddModuleView addModuleView = new AddModuleView(1, 3);
            addModuleView.ShowDialog();
        }
    }
}
