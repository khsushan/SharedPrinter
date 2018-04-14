using MarkPredictor.Views;
using System.ComponentModel;
using System.Windows;

namespace MarkPredictor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window, INotifyPropertyChanged
    {
        private object content;
        private TabView window;
        public MainWindow()
        {
            InitializeComponent();
            window = new TabView();
            SubView = window;
        }

        public object SubView
        {
            get
            {
                return content;
            }

            set
            {
                value = content;
                OnPropertyChanged("SubView");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.window.Show();
            this.Close();
        }
    }
}
