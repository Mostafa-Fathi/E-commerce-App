using E_commerce_App.Models;
using E_commerce_App.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace E_commerce_App.ViewModels
{
    public class EditAccountInfoViewModel : BaseViewModel
    {
        #region Fields

        SharedPreferences sharedPreferences;
        User currentUser;
        private string password;
        ServerRequests httpClient;
        private bool isRunning;
        private string lastName;
        private string firstName;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginWithSocialIconViewModel" /> class.
        /// </summary>
        public EditAccountInfoViewModel()
        {

            this.EditInfoCommand = new Command(this.EditInfoButtonAsync);

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
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (this.firstName == value)
                {
                    return;
                }

                this.SetProperty(ref this.firstName, value);
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (this.lastName == value)
                {
                    return;
                }

                this.SetProperty(ref this.lastName, value);
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


        public Command EditInfoCommand { get; set; }

        #endregion

        #region methods

        private async void EditInfoButtonAsync(object sender)
        {
            if (FirstName != String.Empty && LastName != String.Empty && Password != String.Empty)
            {
                if ((currentUser.password.Equals(Password)))
                {
                    IsRunning = true;
                    User user = currentUser;
                    user.name.firstname = FirstName;
                    user.name.lastname = LastName;
                    

                    bool result = await httpClient.UpdateUserData(user);
                    if (result == true)
                    {
                        IsRunning = false;
                        sharedPreferences.CurrentUserInfo = user;
                        await App.Current.MainPage.DisplayAlert("Done", "First Name and Last Name updated successfully", "OK");
                        await Shell.Current.Navigation.PopToRootAsync();

                    }

                    else
                    {

                        IsRunning = false;
                        await App.Current.MainPage.DisplayAlert("Error", "Error While Update First and Last Name", "OK");

                    }


                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Invalid Input or Wrong Password", "Complete input fields and check your password", "OK");

                }

            }
        }
        #endregion
    }

}
