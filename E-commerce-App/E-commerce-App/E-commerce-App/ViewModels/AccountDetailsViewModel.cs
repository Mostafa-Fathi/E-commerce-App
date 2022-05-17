using E_commerce_App.Models;
using E_commerce_App.Services;
using E_commerce_App.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace E_commerce_App.ViewModels
{
    public class AccountDetailsViewModel : BaseViewModel

    {
        #region Fields

        SharedPreferences sharedPreferences;
        User currentUser;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginWithSocialIconViewModel" /> class.
        /// </summary>
        public AccountDetailsViewModel()
        {

            this.AccountInfoCommand = new Command(this.AccountDetailsClick);
            this.LogOutCommand = new Command(this.LogoutClick);
            this.MyAddressCommand = new Command(this.AddressClick);
            this.MyWishListCommand = new Command(this.FavouriteProductClick);
            this.MyOrdersCommand = new Command(this.OrdersClick);

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
        public string UserName
        {
            get
            {
                return this.currentUser.username;
            }

        }


        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command AccountInfoCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command MyAddressCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Forgot Password button is clicked.
        /// </summary>
        public Command MyOrdersCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the facebook login button is clicked.
        /// </summary>
        public Command MyWishListCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the twitter login button is clicked.
        /// </summary>
        public Command LogOutCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the gmail login button is clicked.
        /// </summary>

        #endregion

        #region methods


        private void AccountDetailsClick(object sender)
        {
            App.Current.MainPage.Navigation.PushAsync(new ProfilePersonally());
        }

        private void AddressClick(object sender)
        {
            if (currentUser.address.Count == 0)
            {
                App.Current.MainPage.Navigation.PushAsync(new MyAddresses());
            }
            else
            {
                App.Current.MainPage.Navigation.PushAsync(new AddedAddressDetails());
            }

        }

        private void OrdersClick(object sender)
        {
            App.Current.MainPage.Navigation.PushAsync(new MyOrders());
        }

        private void FavouriteProductClick(object sender)
        {
            //this alert for testing event Tapped we will change it to navigate to another page
            App.Current.MainPage.Navigation.PushAsync(new WishlistPage());
        }

        private void LogoutClick(object sender)
        {
            sharedPreferences.LogOut();
            Shell.Current.Navigation.PopToRootAsync();
        }

        #endregion

    }
}
