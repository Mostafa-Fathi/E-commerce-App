
using E_commerce_App.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_commerce_App.View.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class Profile : ContentPage
{
    public Profile()
    {
        InitializeComponent();
          
    }

        private void GoToLoginPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginwithSocialIconPage());

        }

        private void GoToSignUpPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }
    }
}