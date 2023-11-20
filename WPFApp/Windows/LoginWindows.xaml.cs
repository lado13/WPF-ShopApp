using System.Windows;
using System.Windows.Controls;
using WPFApp.Members;
using WPFApp.Windows;

namespace WPFApp
{

    public partial class LoginWindows : Window
    {
        public LoginWindows()
        {
            InitializeComponent();
        }

        MembersSystem loginUser = new MembersSystem();

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            loginUser.Login(username, password);
            this.Close();
        }

        private void RecoveryInfo_Click(object sender, RoutedEventArgs e)
        {
            RecoveryWindows recoveryWindows = new RecoveryWindows();
            recoveryWindows.Show();
            this.Close();
        }
    }
}
