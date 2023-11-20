using WPFApp.Members;

namespace WPFApp
{
    interface IMemberMethod
    {
        bool Login(string logName, string password);
        void RecoveryInformation(string name, Member upDateMember);
        void Registration(Member member);
    }
}
