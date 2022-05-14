using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_commerce_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountDetails : ContentPage
    {
        public AccountDetails()
        {
            InitializeComponent();
            Navigation.PopToRootAsync();

            
        }

        private void AccountDetailsClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePersonally());
        }

        private void AddressClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyAddresses());
        }

        private void OrdersClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyOrders());
        }

        private void FavouriteProductClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EmptyWishList());
        }

        private void LogoutClick(object sender, EventArgs e)
        {
            Services.SharedPreferences sharedPreferences = Services.SharedPreferences.Instance;
            sharedPreferences.LogOut();
            Shell.Current.Navigation.PopToRootAsync();
        }
    }
}