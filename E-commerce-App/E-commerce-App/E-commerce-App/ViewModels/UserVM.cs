using E_commerce_App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using E_commerce_App.Models;
namespace E_commerce_App.ViewModel
{
    public class UserVM : INotifyPropertyChanged
    {
        private User currentUser;
        private string userName;
        private string userPassword;

        public string UserPassword
        {
            get { return userPassword; }
            set { userPassword = value; }
        }


        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }


        public User CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }

        private ServerRequests httpClient;

      

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnChangeProperty([CallerMemberName] string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public UserVM()
        {
            httpClient = new ServerRequests();
            
        }
        public async Task<string> Login()
        {
            // 83r5^_  username: mor_2314
            CurrentUser = await httpClient.Login(UserName);
            if (currentUser == null)
            {
                return "User not found";
            }
            if (!(CurrentUser.password.ToLower().Equals(userPassword?.ToLower())))
            {
             
                 return "Wrong password";
            }
            return CurrentUser.username;
        }
        

        
        
    }
}
