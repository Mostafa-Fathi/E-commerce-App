using E_commerce_App.Models;
using E_commerce_App.Services;
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
        
        public CatalogPageViewModel()
        {
            this.FilterOptions = new ObservableCollection<Category>
            {
                new Category
                {
                    name = "Gender",
                    //SubCategories = new List<string>
                    //{
                    //    "Men",
                    //    "Women",
                    //},
                },
                new Category
                {
                    name = "Brand",
                    //SubCategories = new List<string>
                    //{
                    //    "Brand A",
                    //    "Brand B",
                    //},
                },
                new Category
                {
                    name = "Categories",
                    //SubCategories = new List<string>
                    //{
                    //    "Category A",
                    //    "Category B",
                    //},
                },
                new Category
                {
                    name = "Color",
                    //SubCategories = new List<string>
                    //{
                    //    "Maroon",
                    //    "Pink",
                    //},
                },
                new Category
                {
                    name = "Price",
                    //SubCategories = new List<string>
                    //{
                    //    "Above 3000",
                    //    "1000 to 3000",
                    //    "Below 1000",
                    //},
                },
                new Category
                {
                    name = "Size",
                    //SubCategories = new List<string>
                    //{
                    //    "S", "M", "L", "XL", "XXL",
                    //},
                },
                new Category
                {
                    name = "Patterns",
                    //SubCategories = new List<string>
                    //{
                    //    "Pattern 1", "Pattern 2",
                    //},
                },
                new Category
                {
                    name = "Offers",
                    //SubCategories = new List<string>
                    //{
                    //    "Buy 1 Get 1", "Buy 1 Get 2",
                    //},
                },
                new Category
                {
                    name = "Coupons",
                    //SubCategories = new List<string>
                    //{
                    //    "Coupon 1", "Coupon 2",
                    //},
                },
            };

            this.SortOptions = new ObservableCollection<string>
            {
                "New Arrivals",
                "Price - high to low",
                "Price - Low to High",
                "Popularity",
                "Discount",
            };
            httpClient = new ServerRequests();
            loadProducts();
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

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        /// <param name="attachedObject">The Object</param>
        private void ItemSelected(object attachedObject)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the items are sorted.
        /// </summary>
        /// <param name="attachedObject">The Object</param>
        private void SortClicked(object attachedObject)
        {
            // Do something
            List<Product> unOrderdList = new List<Product>(Products);
            // title
            unOrderdList.Sort((a, b) => a.title.CompareTo(b.title));
            Products = new ObservableCollection<Product>(unOrderdList);
            // price 
            List<Product> orderdList= unOrderdList.OrderBy(product=>product.price).ToList<Product>();
            Products = new ObservableCollection<Product>(orderdList);
        }

        /// <summary>
        /// Invoked when the filter button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void FilterClicked(object obj)
        {
            // Do something
            List<Product> unFilterdList = new List<Product>(Products);
            // filter by price more than 100
            //List<Product> filterdList = unFilterdList.Where(o => o.price > 100).ToList();
            // filter by category
            List<Product> filterdList = unFilterdList.Where(o => o.category=="jewelery").ToList();
            Products = new ObservableCollection<Product>(filterdList);
            
        }

        /// <summary>
        /// Invoked when the favourite button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        //private void AddFavouriteClicked(object obj)
        //{
        //    if (obj is Product product)
        //    {
        //        product.IsFavourite = !product.IsFavourite;
        //    }
        //}

        /// <summary>
        /// Invoked when the cart button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
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

        /// <summary>
        /// Invoked when cart icon button is clicked.
        /// </summary>
        /// <param name="obj"></param>
        private void CartClicked(object obj)
        {
            // Do something
            // navigate to cart screen
        }

        private async void loadProducts()
        {
            Products = await httpClient.GetProducts("category/jewelery");
        }

        #endregion
    }
}