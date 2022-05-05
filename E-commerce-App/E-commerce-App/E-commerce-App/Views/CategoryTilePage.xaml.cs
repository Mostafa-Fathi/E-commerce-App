using E_commerce_App.DataService;
using E_commerce_App.ViewModel;
using Syncfusion.ListView.XForms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace E_commerce_App.Views
{
    /// <summary>
    /// The Category Tile page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryTilePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryTilePage" /> class.
        /// </summary>
        public CategoryTilePage()
        {
            this.InitializeComponent();
            this.BindingContext = new CategoryVM();// CategoryDataService.Instance.CategoryPageViewModel;
        }

        //protected override void OnSizeAllocated(double width, double height)
        //{
        //    base.OnSizeAllocated(width, height);

        //    if (width < height)
        //    {
        //        if (this.CategoryTile.LayoutManager is GridLayout)
        //        {
        //            (this.CategoryTile.LayoutManager as GridLayout).SpanCount = 2;
        //        }
        //    }
        //    else
        //    {
        //        if (this.CategoryTile.LayoutManager is GridLayout)
        //        {
        //            (this.CategoryTile.LayoutManager as GridLayout).SpanCount = 3;
        //        }
        //    }
        //}
    }
}