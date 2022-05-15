using E_commerce_App.DataService;
using E_commerce_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace E_commerce_App.Views
{
    /// <summary>
    /// Page to show the wishlist. 
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WishlistPage : ContentPage
    {
        public WishlistPage()
        {
            this.InitializeComponent();
            this.BindingContext = new WishlistPageViewModel();
        }
    }
}