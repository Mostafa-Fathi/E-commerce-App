using E_commerce_App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_App.ViewModels
{
    public class UserVM : INotifyPropertyChanged
    {
        private string token;
        private ServerRequests httpClient;

        public string Token
        {
            get { return token; }
            set { 
                token = value;
                OnChangeProperty();
            }
        }

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
            Token=await httpClient.Login("mor_2314", "83r5^_");
            return Token;
        }
        

        
        
    }
}
