using E_commerce_App.Models;
using E_commerce_App.Services;
using E_commerce_App.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace E_commerce_App.ViewModels
{
    public class ProfilePersonallyViewModel :BaseViewModel
    {
        #region Fields

        SharedPreferences sharedPreferences;
        User currentUser;


        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginWithSocialIconViewModel" /> class.
        /// </summary>
        public ProfilePersonallyViewModel()
        {

            this.EditAccountInfoCommand = new Command(this.EditAccountInfo);
            this.EditEmailCommand = new Command(this.EditEmailPage);
            this.EditPasswordCommand = new Command(this.ResetPassword);
            sharedPreferences = SharedPreferences.Instance;
            currentUser = sharedPreferences.CurrentUserInfo;


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
                return this.currentUser.email;
            }
        }
        public string FirstName
        {
            get
            {
                return this.currentUser.name.firstname;
            }
        }
        public string LastName
        {
            get
            {
                return this.currentUser.name.lastname;
            }
        }


        #endregion

        #region Command

        public Command EditAccountInfoCommand { get; set; }


        public Command EditEmailCommand { get; set; }

        public Command EditPasswordCommand { get; set; }



        #endregion

        #region methods


        private void EditEmailPage(object sender)
        {
            App.Current.MainPage.Navigation.PushAsync(new EditEmail());
        }

        private void EditAccountInfo(object sender)
        {
            App.Current.MainPage.Navigation.PushAsync(new EditAccountInfo());
        }

        private void ResetPassword(object sender)
        {
            App.Current.MainPage.Navigation.PushAsync(new ResetPassword());
        }
        #endregion
    }
}
