using E_commerce_App.DataService;
using E_commerce_App.ViewModels;
using Syncfusion.ListView.XForms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace E_commerce_App.Views
{
    /// <summary>
    /// Page to show Catalog tile.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductTilePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTilePage" /> class.
        /// </summary>
       
        public ProductTilePage(string categoryName)
        {
            this.InitializeComponent();
            this.BindingContext = new CatalogPageViewModel(categoryName);
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width < height)
            {
                if (this.ListViewTile.LayoutManager is GridLayout)
                {
                    (this.ListViewTile.LayoutManager as GridLayout).SpanCount = 2;
                }
            }
            else
            {
                if (this.ListViewTile.LayoutManager is GridLayout)
                {
                    (this.ListViewTile.LayoutManager as GridLayout).SpanCount = 4;
                }
            }
        }

        private void ProductSelect(object sender, ItemTappedEventArgs e)
        {
            DisplayAlert("alert", "alert", "ok");
        }

        
    }
}