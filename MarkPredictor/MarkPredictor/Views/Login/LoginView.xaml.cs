using MarkPredictor.Controllers.Account;
using MarkPredictor.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MarkPredictor.Views.Login
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private AccountController _accountController;

        public LoginView()
        {
            _accountController = new AccountController();
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private async void okBtn_Click(object sender, RoutedEventArgs e)
        {
            var password = passwordText.Password;
            var userName = userNameText.Text;
            if (password.Trim() != string.Empty && userName.Trim() != string.Empty)
            {
                var studentDto = await _accountController.login(new StudentDto { UserName = userName, Password = password });
                if (studentDto.Id != 0 && studentDto.Password != string.Empty)
                {
                    MainWindow mainWindow = new MainWindow(studentDto.CourseId);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid login details", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
