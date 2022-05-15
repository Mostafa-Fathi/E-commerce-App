using E_commerce_App.Models;
using E_commerce_App.Services;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace E_commerce_App.ViewModels
{
    public class EditEmailViewModel : BaseViewModel
    {
        #region Fields

        SharedPreferences sharedPreferences;
        User currentUser;
        private string email="";
        private string password="";
        ServerRequests httpClient;
        private bool isRunning;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginWithSocialIconViewModel" /> class.
        /// </summary>
        public EditEmailViewModel()
        {

            this.EditEmailCommand = new Command(this.EditEmailButtonAsync);

            sharedPreferences = SharedPreferences.Instance;
            currentUser = sharedPreferences.CurrentUserInfo;
            httpClient = new ServerRequests();
            isRunning =false;


        }


        #endregion

        #region property

        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (this.email == value)
                {
                    return;
                }

                this.SetProperty(ref this.email, value);
            }
        }
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password == value)
                {
                    return;
                }

                this.SetProperty(ref this.password, value);
            }
        }

        public bool IsRunning
        {
            get
            {
                return this.isRunning;
            }

            set
            {
                if (this.isRunning == value)
                {
                    return;
                }

                this.SetProperty(ref this.isRunning, value);
            }
        }

        #endregion

        #region Command


        public Command EditEmailCommand { get; set; }

        #endregion

        #region methods
        private bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private async void EditEmailButtonAsync(object sender)
        {
            if (Email != String.Empty && Password != String.Empty && IsValid(Email))
            {
                if ((currentUser.password.Equals(Password)))
                {
                    IsRunning = true;
                    User user = await httpClient.CheckEmail(Email);
                    if (user == null)
                    {
                        //can change email
                        user = currentUser;
                        user.email = Email;
                        bool result = await httpClient.UpdateUserData(user);
                        if (result == true)
                        {
                            IsRunning = false;
                            sharedPreferences.CurrentUserInfo = user;
                            await App.Current.MainPage.DisplayAlert("Done ", "Email updated successfully", "OK");
                            await Shell.Current.Navigation.PopToRootAsync();

                        }

                        else
                        {

                            IsRunning = false;
                            await App.Current.MainPage.DisplayAlert("Error", "Error While Update Email", "OK");

                        }
                    }
                    else
                    {
                        IsRunning = false;
                        await App.Current.MainPage.DisplayAlert("Error", "Email is already existed", "OK");

                    }

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Check Email and Password", "You entered Wrong Password or not valid email ", "OK");

                }

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Wrong input", "You must compelte input fields", "OK");
            }
        }
        #endregion
    }
}
