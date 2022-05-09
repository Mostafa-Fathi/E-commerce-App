using E_commerce_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;

namespace E_commerce_App.Services
{
    public sealed class SharedPreferences: INotifyPropertyChanged
    {
        private SharedPreferences() { }
        private static SharedPreferences instance = null;
        public static SharedPreferences Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SharedPreferences();
                }
                return instance;
            }
        }

        private bool isLoggedIn;

        public bool IsLoggedIn
        {
            get
            {
                isLoggedIn = Preferences.ContainsKey("UserInfo");
                return isLoggedIn;
            }
        }

        private User currentUserInfo;

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void LogOut() {
            Preferences.Remove("UserInfo");
            currentUserInfo = null;
            OnPropertyChanged("CurrentUserInfo");
        }

        public User CurrentUserInfo
        {
            get { string temp =Preferences.Get("UserInfo","null");
                if (temp != "null") {
                    currentUserInfo= JsonConvert.DeserializeObject<User>(temp);
                    return currentUserInfo ;
                }
                else return null;
            }
            set {
                Preferences.Set("UserInfo", JsonConvert.SerializeObject(value));
                OnPropertyChanged("CurrentUserInfo");

            }
        }
        

    }
}
