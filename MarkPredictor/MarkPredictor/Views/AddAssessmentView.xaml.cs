using MarkPredictor.Dto;
using System.Collections.Generic;
using System.ComponentModel;

namespace MarkPredictor.Views
{
    /// <summary>
    /// Interaction logic for AddAssigmentView.xaml
    /// </summary>
    public partial class AddAssesmentView : System.Windows.Window, INotifyPropertyChanged
    {
        private int _level = 0;
        private IList<string> _assigmentTypes;
        public string _selectedAssigmentType;
        public event PropertyChangedEventHandler PropertyChanged;


        public AddAssesmentView()
        {
            _assigmentTypes = new List<string>();
            _assigmentTypes.Add("Exam");
            _assigmentTypes.Add("Courese Work");
            _selectedAssigmentType = _assigmentTypes[0];
            AssigmentTypes = _assigmentTypes;
            this.DataContext = this;
            InitializeComponent();

        }

        public AddAssesmentView(int moduleId) : this()
        {
            _level = moduleId;
        }

        public IList<string> AssigmentTypes
        {
            get { return _assigmentTypes; }
            set
            {
                _assigmentTypes = value;
                OnPropertyChanged("AssigmentTypes");
            }
        }

        public string SelectedAssigmentType
        {
            get { return _selectedAssigmentType; }
            set
            {
                _selectedAssigmentType = value;
                OnPropertyChanged("SelectedAssigmentType");
            }
        }



        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void okBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string assigmentName = assigmentNameText.Text;
            double assigmentPrecentage = double.Parse(assigmentPrecentageText.Text);
            if (assigmentName.Trim() !=  string.Empty && assigmentPrecentage < 0)
            {
                AssessmenttDto assigmentDto = new AssessmenttDto
                {
                    Name = assigmentName,
                    Precentage = assigmentPrecentage
                };
            }
        }
    }
}
