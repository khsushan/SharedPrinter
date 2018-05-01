using MarkPredictor.Views;
using System.ComponentModel;
using System.Windows;

namespace MarkPredictor.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window, INotifyPropertyChanged
    {
        private TabView window;
        private long _courseId;

        public MainWindow(long courseId)
        {
            InitializeComponent();;
            _courseId = courseId;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
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
            window = new TabView(_courseId);
            this.window.Show();
            this.Close();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].Close();
        }
    }
}
