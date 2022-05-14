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
    public partial class EmptyWishList : ContentPage
    {
        public EmptyWishList()
        {
            InitializeComponent();
        }

        private void GoToCategoryPage(object sender, EventArgs e)
        {
           //Navigation.PushAsync(new Views.Pages.Categories());
           //Navigation.PushAsync(new NavigationPage(new Views.Pages.Categories()));
        }
    }
}