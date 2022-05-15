using E_commerce_App.DataService;
using E_commerce_App.ViewModels;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace E_commerce_App.Views
{
    /// <summary>
    /// Page to show the cart list. 
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CartPage" /> class.
        /// </summary>
        public CartPage()
        {
            this.InitializeComponent();
            this.BindingContext = new CartPageViewModel();
        }
    }
}