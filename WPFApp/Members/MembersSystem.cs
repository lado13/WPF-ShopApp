using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WPFApp.Members
{
    class MembersSystem : Member, IMemberMethod
    {
        private static int lastID = 0;
        private static bool active = false;
        private static List<Member> members = new List<Member>()
        {
            new Member() {Id=1, Name="lado", LastName="bartia", Email="lado@gmail.com", Password="1234", IsActive = active}
        };

        public MembersSystem()
        {
            Id = lastID++;
            IsActive = active;
        }



        public bool Login(string logName, string password)
        {
            try
            {
                Member member = members.Find(m => m.Name == logName && m.Password == password);
                if (member != null)
                {
                    active = true;
                }
                else
                {
                    MessageBox.Show("Incorrect login or password", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
                
                return member != null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RecoveryInformation(string name, Member upDateMember)
        {
            try
            {
                Member recoveryMember = members.FirstOrDefault(x => x.Name == name);
                if (recoveryMember != null)
                {
                    recoveryMember.Password = upDateMember.Password;
                    MessageBox.Show("Successfully updated", "Okay", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("User not found!", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Registration(Member member)
        {
            try
            {
                if (members.Any(user => user.Name == member.Name && user.Password == member.Password))
                {
                    MessageBox.Show("Username or password already exists!!!", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
                else
                {
                    members.Add(member);
                    MessageBox.Show("Registered successfully", "Okay", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


       





    }
}
