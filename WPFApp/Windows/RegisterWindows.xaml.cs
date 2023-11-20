using System.Text.RegularExpressions;
using System.Windows;
using WPFApp.Members;

namespace WPFApp.Windows
{
    public partial class RegisterWindows : Window
    {
        MembersSystem membersSystem = new MembersSystem();
        public RegisterWindows()
        {
            InitializeComponent();
        }
        
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            MembersSystem member = new MembersSystem();
            member.Name = NameInp.Text;
            member.LastName = LastNameInp.Text;
            member.Email = EmailInp.Text;
            member.Password = PasswordInp.Password; 

            string patern = "@.";
            bool isMatch = Regex.IsMatch(member.Email, patern);

            if (isMatch)
            {
                membersSystem.Registration(member);
            }
            else
            {
                MessageBox.Show("Incorrect Email!!!", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
            this.Close();
        
        }
    }
}
