using MarkPredictor.Common;
using MarkPredictor.Controllers.Module;
using MarkPredictor.Dto;
using System.Windows;

namespace MarkPredictor.Views
{
    /// <summary>
    /// Interaction logic for AddModuleView.xaml
    /// </summary>
    public partial class AddModuleView : Window
    {
        private long _levelId;
        private long _courseId;
        private IModuleController _moduleController;

        public AddModuleView()
        {
            InitializeComponent();
            _moduleController = InstanceFactory.GetModulControllerInstance();
        }

        public AddModuleView(long courseId, long levelId) : this()
        {
            _courseId = courseId;
            _levelId = levelId;
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            if (moduleNameText.Text.Trim() != string.Empty)
            {
                ModuleDto moduleDto = new ModuleDto
                {
                    ModuleName = moduleNameText.Text,
                    CourseId = _courseId,
                    LevelId = _levelId
                };
                _moduleController.AddModule(moduleDto);
                moduleNameText.Text = string.Empty;
            }
        }
    }
}
