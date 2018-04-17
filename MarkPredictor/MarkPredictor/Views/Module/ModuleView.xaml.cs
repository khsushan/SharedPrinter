using MarkPredictor.Dto;
using Prism.Events;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MarkPredictor.Views.Module
{
    /// <summary>
    /// Interaction logic for ModuleView.xaml
    /// </summary>
    public partial class ModuleView : UserControl
    {
        private ModuleDto _moduleDto;
        private readonly IEventAggregator eventAggregator;

        public ModuleView(ModuleDto moduleDto)
        {
            InitializeComponent();           
            _moduleDto = moduleDto;
            moduleNameLable.Content = moduleDto.ModuleName;
            assessmentList.ItemsSource = moduleDto.Assessments;
            eventAggregator = new EventAggregator();
            assessmentList.CellEditEnding += assementList_CellEditEnding;

        }

        private void addAssementBtn_Click(object sender, RoutedEventArgs e)
        {
            AddAssesmentView addAssesmentView = new AddAssesmentView(_moduleDto.Id);
            addAssesmentView.Show();
        }

        private void assementList_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var column = e.Column as DataGridBoundColumn;
                if (column != null)
                {
                    var bindingPath = (column.Binding as Binding).Path.Path;
                    if (bindingPath == "Mark")
                    {
                        int rowIndex = e.Row.GetIndex();
                        var el = e.EditingElement as TextBox;
                        var text = el.Text;
                        // rowIndex has the row index
                        // bindingPath has the column's binding
                        // el.Text has the new, user-entered value
                    }
                }
            }
        }

    }
}
