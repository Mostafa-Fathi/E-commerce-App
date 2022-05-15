using E_commerce_App.Models;
using E_commerce_App.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace E_commerce_App.ViewModels
{
    public class ResetPasswordViewModel : BaseViewModel
    {
        #region Fields

        SharedPreferences sharedPreferences;
        User currentUser;
        private string currentPassword = "";
        ServerRequests httpClient;
        private bool isRunning;
        private string newPassword = "";
        private string confirmNewPassword = "";

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginWithSocialIconViewModel" /> class.
        /// </summary>
        public ResetPasswordViewModel()
        {

            this.ResetPasswordCommand = new Command(this.ResetPasswordButtonAsync);

            sharedPreferences = SharedPreferences.Instance;
            currentUser = sharedPreferences.CurrentUserInfo;
            httpClient = new ServerRequests();
            isRunning = false;


        }


        #endregion

        #region property

        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public string CurrentPassword
        {
            get
            {
                return this.currentPassword;
            }

            set
            {
                if (this.currentPassword == value)
                {
                    return;
                }

                this.SetProperty(ref this.currentPassword, value);
            }
        }
        public string NewPassword
        {
            get
            {
                return this.newPassword;
            }

            set
            {
                if (this.newPassword == value)
                {
                    return;
                }

                this.SetProperty(ref this.newPassword, value);
            }
        }
        public string ConfrimNewPassword
        {
            get
            {
                return this.confirmNewPassword;
            }

            set
            {
                if (this.confirmNewPassword == value)
                {
                    return;
                }

                this.SetProperty(ref this.confirmNewPassword, value);
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


        public Command ResetPasswordCommand { get; set; }

        #endregion

        #region methods

        private async void ResetPasswordButtonAsync(object sender)
        {
            if (NewPassword == ConfrimNewPassword && ConfrimNewPassword != String.Empty && NewPassword != String.Empty)
            {
                if ((currentUser.password.Equals(CurrentPassword)))
                {
                    Regex RegexPassword = new Regex("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,20}$");
                    if (RegexPassword.IsMatch(NewPassword))
                    {
                        IsRunning = true;
                        User user = currentUser;
                        user.password = NewPassword;
                        bool result = await httpClient.UpdateUserData(user);

                        if (result == true)
                        {
                            IsRunning = false;
                            sharedPreferences.CurrentUserInfo = user;
                            await App.Current.MainPage.DisplayAlert("Done", "Password updated successfully", "OK");
                            await Shell.Current.Navigation.PopToRootAsync();

                        }
                        else
                        {

                            IsRunning = false;
                            await App.Current.MainPage.DisplayAlert("Error", "Error While Update Password", "OK");

                        }


                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Invalid Input for new Password", "New Password is invalid must be from 8-20 and at least contains one digit and one letter", "OK");

                    }

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Wrong Password", "wrong current Password", "OK");

                }

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Invalid Input", "Complete input fields", "OK");

            }

        }
        #endregion
    }
}
