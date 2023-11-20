using System.Windows;
using WPFApp.Members;

namespace WPFApp.Windows
{
    /// <summary>
    /// Interaction logic for RecoveryWindows.xaml
    /// </summary>
    public partial class RecoveryWindows : Window
    {
        public RecoveryWindows()
        {
            InitializeComponent();
        }

        MembersSystem MembersSystem = new MembersSystem();

        private void RecoveryButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameInp.Text;
            MembersSystem recoveryMember = new MembersSystem();
            recoveryMember.Name = NameInp.Text;
            recoveryMember.LastName = LastNameInp.Text; 
            recoveryMember.Email = EmailInp.Text;
            recoveryMember.Password = PasswordInp.Password;
            MembersSystem.RecoveryInformation(name,recoveryMember);
            this.Close();
        }
    }
}
