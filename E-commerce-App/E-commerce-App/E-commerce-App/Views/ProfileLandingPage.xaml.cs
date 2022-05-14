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
    public partial class ProfileLandingPage : ContentPage
    {
        public ProfileLandingPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Services.SharedPreferences sharedPreferences = Services.SharedPreferences.Instance;
            if (sharedPreferences.IsLoggedIn)
            {
                Shell.Current.Navigation.PushAsync(new AccountDetails(),false);
            }
            else
            {
                Shell.Current.Navigation.PushAsync(new Pages.Profile(),false);
            }
        }
    }
}