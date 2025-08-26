using LyricSync.Desktop.ViewModels;
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

namespace LyricSync.Desktop.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();

            var vm = new LoginViewModel();
            DataContext = vm;

            LoginCommand = vm.LoginCommand;
            PasswordBox.PasswordChanged += (s, e) => vm.Password = PasswordBox.Password;
        }

        public ICommand LoginCommand { get; set; }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (LoginCommand.CanExecute(null))
                LoginCommand.Execute(null);
        }
    }
}
