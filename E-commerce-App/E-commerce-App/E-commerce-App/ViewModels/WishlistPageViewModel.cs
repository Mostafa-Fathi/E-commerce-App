using E_commerce_App.Models;
using E_commerce_App.Services;
using E_commerce_App.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace E_commerce_App.ViewModels
{
    /// <summary>
    /// ViewModel for wishlist page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class WishlistPageViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<Product> wishlistDetails;
        private ServerRequests httpClient = new ServerRequests();
        private double totalPrice;

        private double discountPrice;

        private double discountPercent;

        private double percent;

        private int? cartItemCount;

        private ObservableCollection<Product> produts;

        private Command cardItemCommand;

        private Command addToCartCommand;
        private Command removeFromFavs;

        private Command deleteCommand;

        private Command quantitySelectedCommand;

        private Command itemTappedCommand;
        private Command pageAppearingCommand;
      

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the property that has been bound with a list view, which displays the wishlist details.
        /// </summary>
        public ObservableCollection<Product> WishlistDetails
        {
            get
            {
                return this.wishlistDetails;
            }

            private set
            {
                if (this.wishlistDetails == value)
                {
                    return;
                }

                this.SetProperty(ref this.wishlistDetails, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the total price.
        /// </summary>
        public double TotalPrice
        {
            get
            {
                return this.totalPrice;
            }

            set
            {
                if (this.totalPrice == value)
                {
                    return;
                }

                this.SetProperty(ref this.totalPrice, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays total discount price.
        /// </summary>
        public double DiscountPrice
        {
            get
            {
                return this.discountPrice;
            }

            set
            {
                if (this.discountPrice == value)
                {
                    return;
                }

                this.SetProperty(ref this.discountPrice, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays discount.
        /// </summary>
        public double DiscountPercent
        {
            get
            {
                return this.discountPercent;
            }

            set
            {
                if (this.discountPercent == value)
                {
                    return;
                }

                this.SetProperty(ref this.discountPercent, value);
            }
        }
        public Command PageAppearingCommand
        {
            get
            {
                return (this.pageAppearingCommand ?? (this.pageAppearingCommand = new Command(this.PageAppearing)));
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with view, which displays the cart items count.
        /// </summary>
        public int? CartItemCount
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

        /// <summary>
        /// Gets or sets the property that has been bound with list view, which displays the collection of products from json.
        /// </summary>
        [DataMember(Name = "products")]
        public ObservableCollection<Product> Products
        {
            get
            {
                return this.produts;
            }

            set
            {
                if (this.produts == value)
                {
                    return;
                }

                this.SetProperty(ref this.produts, value);
                this.GetProducts(this.Products);
              //  this.UpdatePrice();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets the command will be executed when the cart button has been clicked.
        /// </summary>
        public Command CardItemCommand
        {
            get
            {
                return this.cardItemCommand ?? (this.cardItemCommand = new Command(this.CartClicked));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when the AddToCart button is clicked.
        /// </summary>
        public Command AddToCartCommand
        {
            get
            {
                return this.addToCartCommand ?? (this.addToCartCommand = new Command(this.AddToCartClicked));
            }
        }
        public Command RemoveFromFavs
        {
            get
            {
                return this.removeFromFavs ?? (this.removeFromFavs = new Command(this.RemoveFromFavsClicked));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when the Remove button is clicked.
        /// </summary>
        public Command DeleteCommand
        {
            get
            {
                return this.deleteCommand ?? (this.deleteCommand = new Command(this.DeleteClicked));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when the quantity is selected.
        /// </summary>
        public Command QuantitySelectedCommand
        {
            get
            {
                return this.quantitySelectedCommand ?? (this.quantitySelectedCommand = new Command(this.QuantitySelected));
            }
        }

        /// <summary>
        /// Gets the command that is executed when the item is selected.
        /// </summary>
        public Command ItemTappedCommand
        {
            get
            {
                return this.itemTappedCommand ?? (this.itemTappedCommand = new Command(this.ItemSelected));
            }
        }

        #endregion

        #region Constructor
        public WishlistPageViewModel()
        {
            loadData();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Invoked when cart button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        /// 
        private async void loadData()
        {
            WishlistDetails = await httpClient.GetFavProducts();
        }
        private async void CartClicked(object obj)
        {
            // Do something
             await Application.Current.MainPage.Navigation.PushAsync(new CartPage());
            //CartPage
           


        }

        /// <summary>
        /// Invoked when add to cart button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void AddToCartClicked(object obj)
        {
           
            Product SelectedProduct = obj as Product;
            int statusCode = await httpClient.addProductToCart(SelectedProduct);
            if (statusCode == 500)
            {
                await Application.Current.MainPage.DisplayAlert("Cart", "Item already exist", "OK");
            }
            else if (statusCode == 201)
            {
                this.cartItemCount = this.cartItemCount ?? 0;
                this.CartItemCount += 1;
                await Application.Current.MainPage.DisplayAlert("Cart", "Added Item", "OK");

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Network Error", "Check your connection", "OK");
            }
        }
        
        private async void RemoveFromFavsClicked(object obj)
        {
            Product SelectedProduct = obj as Product;
            WishlistDetails.Remove(WishlistDetails.Where(i => i.id == SelectedProduct.id).Single());
            SelectedProduct.isFavourite = false;
            await httpClient.addRemoveFavourites(SelectedProduct);
        }

        /// <summary>
        /// Invoked when an delete button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void DeleteClicked(object obj)
        {
            if (this.WishlistDetails.Count > 0)
            {
                this.WishlistDetails.Remove(obj as Product);
            }
        }

        /// <summary>
        /// Invoked when the quantity is selected.
        /// </summary>
        /// <param name="selectedItem">The Object</param>
        private void QuantitySelected(object selectedItem)
        {
        }

        /// <summary>
        /// Invoked when item is clicked.
        /// </summary>
        private void ItemSelected(object obj)
        {
            // Do something
        }

        /// <summary>
        /// This method is used to get the products from json.
        /// </summary>
        /// <param name="products">The products</param>
        private void GetProducts(ObservableCollection<Product> products)
        {
            this.WishlistDetails = new ObservableCollection<Product>();
            if (products != null && products.Count > 0)
            {
                this.WishlistDetails = products;
            }
        }

        /// <summary>
        /// This method is used to update the price amount.
        /// </summary>
        private void UpdatePrice()
        {
            this.ResetPriceValue();

            if (this.WishlistDetails != null && this.WishlistDetails.Count > 0)
            {
                foreach (var wishlistDetail in this.WishlistDetails)
                {
                    if (wishlistDetail.totalQuantity == 0)
                    {
                        wishlistDetail.totalQuantity = 1;
                    }

                    this.TotalPrice += wishlistDetail.actualPrice * wishlistDetail.totalQuantity;
                    this.DiscountPrice += wishlistDetail.discountPrice * wishlistDetail.totalQuantity;
                    this.percent += wishlistDetail.discountPercent;
                }

                this.DiscountPercent = this.percent > 0 ? this.percent / this.WishlistDetails.Count : 0;
            }
        }

        /// <summary>
        /// This method is used to reset the price amount.
        /// </summary>
        private void ResetPriceValue()
        {
            this.TotalPrice = 0;
            this.DiscountPercent = 0;
            this.DiscountPrice = 0;
            this.percent = 0;
        }

        private void PageAppearing()
        {
            loadData();
        }

        #endregion
    }
}
