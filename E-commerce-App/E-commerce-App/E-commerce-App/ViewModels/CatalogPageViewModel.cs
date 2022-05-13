using E_commerce_App.Models;
using E_commerce_App.Services;
using E_commerce_App.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace E_commerce_App.ViewModels
{
    /// <summary>
    /// ViewModel for catalog page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class CatalogPageViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<Category> filterOptions;
        private ServerRequests httpClient;
        private ObservableCollection<string> sortOptions;
        private Category selectedFilter;
        private string selectedSort;
        private Command addFavouriteCommand;

        private Command itemSelectedCommand;

        private Command sortCommand;

        private Command filterCommand;

        private Command addToCartCommand;

        private Command cardItemCommand;

        private string cartItemCount;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="CatalogPageViewModel" /> class.
        /// </summary>

        public CatalogPageViewModel(string categoryName)
        {


            this.SortOptions = new ObservableCollection<string>
            {
                "Price - High to Low",
                "Price - Low to High",
            };
            httpClient = new ServerRequests();
            loadProducts(categoryName);
            FilterOptions = new ObservableCollection<Category>()
           {
               new Category(){name="loading"}
           };
            loadCategories();
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the property that has been bound with a list view, which displays the item details in tile.
        /// </summary>
        [DataMember(Name = "products")]
        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set {
                products = value;
                NotifyPropertyChanged();
            }
        }
        private ObservableCollection<Product> cart;
        public ObservableCollection<Product> Cart
        {
            get { return cart; }
            set {
                cart = value;
                NotifyPropertyChanged();
            }
        }


        public Category SelectedFilter{
            get { return selectedFilter; }
            set { 
                this.selectedFilter = value;
                this.FilterClicked();
                NotifyPropertyChanged();
            }
        }
        public string SelectedSort
        {
            get { return selectedSort; }
            set
            {
                this.selectedSort = value;
                this.SortClicked();
                NotifyPropertyChanged();
            }
        }
        

        /// <summary>
        /// Gets or sets the property that has been bound with a list view, which displays the filter options.
        /// </summary>
        public ObservableCollection<Category> FilterOptions
        {
            get
            {
                return this.filterOptions;
            }

            private set
            {
                if (this.filterOptions == value)
                {
                    return;
                }

                this.SetProperty(ref this.filterOptions, value);
            }
        }

        /// <summary>
        /// Gets or sets the property has been bound with a list view, which displays the sort details.
        /// </summary>
        public ObservableCollection<string> SortOptions
        {
            get
            {
                return this.sortOptions;
            }

            private set
            {
                if (this.sortOptions == value)
                {
                    return;
                }

                this.SetProperty(ref this.sortOptions, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with view, which displays the cart items count.
        /// </summary>
        public string CartItemCount
        {
            get
            {
                return this.cartItemCount;
            }

            set
            {
                this.SetProperty(ref this.cartItemCount, value);
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand
        {
            get { return this.itemSelectedCommand ?? (this.itemSelectedCommand = new Command(this.ItemSelected)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the sort button is clicked.
        /// </summary>
        public Command SortCommand
        {
            get { return this.sortCommand ?? (this.sortCommand = new Command(this.SortClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the filter button is clicked.
        /// </summary>
        public Command FilterCommand
        {
            get { return this.filterCommand ?? (this.filterCommand = new Command(this.FilterClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the Favourite button is clicked.
        ///// </summary>
        //public Command AddFavouriteCommand
        //{
        //    get
        //    {
        //        return this.addFavouriteCommand ?? (this.addFavouriteCommand = new Command(this.AddFavouriteClicked));
        //    }
        //}

        /// <summary>
        /// Gets or sets the command that will be executed when the AddToCart button is clicked.
        /// </summary>
        public Command AddToCartCommand
        {
            get { return this.addToCartCommand ?? (this.addToCartCommand = new Command(this.AddToCartClicked)); }
        }

        /// <summary>
        /// Gets or sets the command will be executed when the cart icon button has been clicked.
        /// </summary>
        public Command CardItemCommand
        {
            get { return this.cardItemCommand ?? (this.cardItemCommand = new Command(this.CartClicked)); }
        }

        #endregion

        #region Methods
        private async void ItemSelected(object attachedObject)
        {   Product product = (Product)attachedObject;
            // Do something
            await Application.Current.MainPage.Navigation.PushAsync(new DetailPage(product));

        }
        private void SortClicked()
        {
            // Do something
            List<Product> unOrderdList = new List<Product>(Products);
            List<Product> orderdList;
            switch (selectedSort)
            {
                case "Price - High to Low":
                    orderdList = unOrderdList.OrderBy(product => product.price).ToList<Product>();
                    Products = new ObservableCollection<Product>(orderdList);
                    break;
                case "Price - Low to High":
                    orderdList = unOrderdList.OrderByDescending(product => product.price).ToList<Product>();
                    Products = new ObservableCollection<Product>(orderdList);
                    break;


            }
            // price 
            
        }

        private void FilterClicked()
        {
            // Do something
            List<Product> unFilterdList = new List<Product>(Products);
            // filter by price more than 100
            //List<Product> filterdList = unFilterdList.Where(o => o.price > 100).ToList();
            // filter by category
            if (selectedFilter.name == "all")
            {
                loadAllProducts();
            }
            else
            {
                loadProducts(selectedFilter.name);
            }

            
        }

       
        //private void AddFavouriteClicked(object obj)
        //{
        //    if (obj is Product product)
        //    {
        //        product.IsFavourite = !product.IsFavourite;
        //    }
        //}

        private void AddToCartClicked(object obj)
        {
            // Do something
            if (Cart == null)
            {
                Cart = new ObservableCollection<Product>()
                {
                    // selected item
                };
            }
            else
            {
                //Cart.Add(selectedItem);
            }
        }
        private void CartClicked(object obj)
        {
            // Do something
            // navigate to cart screen
        }

        private async void loadProducts(string categoryName)
        {
          //  await Application.Current.MainPage.DisplayAlert(categoryName, "", "ok");
            Products = await httpClient.GetSelectedProducts($"{categoryName}");
        }
        private async void loadAllProducts()
        {
            Products = await httpClient.GetProducts();
        }
        private async void loadCategories() {
            FilterOptions = await httpClient.GetCategories();
            FilterOptions.Add(new Category() { name = "all" });
        }
        #endregion
    }
}