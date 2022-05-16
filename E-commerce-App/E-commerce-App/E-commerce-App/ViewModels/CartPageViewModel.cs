using E_commerce_App.Models;
using E_commerce_App.Services;
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace E_commerce_App.ViewModels
{
    /// <summary>
    /// ViewModel for cart page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class CartPageViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<CartProductItem> cartDetails;
        private ServerRequests httpRequest= new ServerRequests();
        private double totalPrice;

        private double discountPrice;

        private double discountPercent;
        private int quantity;

        private double percent;

        private ObservableCollection<CartProductItem> produts;

        private Command placeOrderCommand;

        private Command removeCommand;
        private Command plusQuantityCommand;

        private Command quantitySelectedCommand;

        private Command variantSelectedCommand;

        private Command applyCouponCommand;

        private Command itemTappedCommand;
        private Command pageAppearingCommand;
        #endregion

        #region
        public CartPageViewModel()
        {
            CartDetails = new ObservableCollection<CartProductItem>() {
                new CartProductItem(){
                id= 2,
                title= "Mens Casual Premium Slim Fit T-Shirts ",
                description= "Slim-fitting style, contrast raglan long sleeve, three-button henley placket, light weight & soft fabric for breathable and comfortable wearing. And Solid stitched shirts with round neck made for durability and a great fit for casual fashion wear and diehard baseball fans. The Henley style round neckline includes a three-button placket.",
                category= "men's clothing",
                image= new Uri("https://fakestoreapi.com/img/71-3HjGNDUL._AC_SY879._SX._UX._SY._UY_.jpg"),
                totalQuantity= 0,
                actualPrice= 22,
                discountPercent= 0,
                discountPrice= 0,
                isFavourite= false,
                quantity = 1,
                rating= new Rating(){rate=4, count=259}
    }


            };
            loadData();
        }
        #endregion

        #region Public properties 

        public ObservableCollection<CartProductItem> CartDetails
        {
            get
            {
                return this.cartDetails;
            }

            private set
            {
                if (this.cartDetails == value)
                {
                    return;
                }
                NotifyPropertyChanged();
                this.SetProperty(ref this.cartDetails, value);
            }
        }

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
      
        /*  
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
                      //  this.GetProducts(this.Products);
                        this.UpdatePrice();
                        NotifyPropertyChanged();
                    }
                }
        */

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that will be executed when the Edit button is clicked.
        /// </summary>
        public Command PlaceOrderCommand
        {
            get { return this.placeOrderCommand ?? (this.placeOrderCommand = new Command(this.PlaceOrderClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the Remove button is clicked.
        /// </summary>
        public Command RemoveCommand
        {
            get { return this.removeCommand ?? (this.removeCommand = new Command(this.RemoveClicked)); }
        } 
        public Command PlusQuantityCommand
        {
            get { return this.plusQuantityCommand ?? (this.plusQuantityCommand = new Command(this.PlusQuantityClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the quantity is selected.
        /// </summary>
        public Command QuantitySelectedCommand
        {
            get { return this.quantitySelectedCommand ?? (this.quantitySelectedCommand = new Command(this.QuantitySelected)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the variant is selected.
        /// </summary>
        public Command VariantSelectedCommand
        {
            get { return this.variantSelectedCommand ?? (this.variantSelectedCommand = new Command(this.VariantSelected)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the apply coupon is clicked.
        /// </summary>
        public Command ApplyCouponCommand
        {
            get { return this.applyCouponCommand ?? (this.applyCouponCommand = new Command(this.ApplyCouponClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that is executed when the item is selected.
        /// </summary>
        public Command ItemTappedCommand
        {
            get
            {
                return this.itemTappedCommand ?? (this.itemTappedCommand = new Command(this.ItemSelected));
            }
        }
        public Command PageAppearingCommand
        {
            get
            {
                return (this.pageAppearingCommand ?? (this.pageAppearingCommand = new Command(this.PageAppearing)));
            }
        }

        #endregion

        #region Methods
        private void PageAppearing()
        {
            loadData();
        }
        private void PlaceOrderClicked(object obj)
        {
            Application.Current.MainPage.DisplayAlert("PlaceOrderClicked", "Order", "OK");
        }
        private async void loadData()
        {
            CartDetails = await httpRequest.getProductFromCart();
            this.UpdatePrice();
        }
        private async void RemoveClicked(object obj)
        {
            if (obj is CartProductItem product)
            {
                this.CartDetails.Remove(product);
                this.UpdatePrice();
                await httpRequest.removeFromCart(product.id);
            }
        }
         private  void PlusQuantityClicked(object obj)
        {
            this.quantity++;
            Application.Current.MainPage.DisplayAlert("New Quantity", this.quantity.ToString(), "OK");
        }
        
        private void QuantitySelected(object selectedItem)
        {
            // Incident - 249030 - Issue in ComboBox Slection changed event.

            // var item = selectedItem as CartProduct;

            // this.UpdatePrice();
            // item.actualPrice = item.actualPrice * item.totalQuantity;
            // item.DiscountPrice = item.DiscountPrice * item.totalQuantity;
        }

        private void VariantSelected(object obj)
        {
            // Do something
        }

        private void ApplyCouponClicked(object obj)
        {
            // Do something
        }

        private void ItemSelected(object obj)
        {
            // Do something
        }

        private void GetProducts(ObservableCollection<CartProductItem> products)
        {
            this.CartDetails = new ObservableCollection<CartProductItem>();
            if (products != null && products.Count > 0)
            {
                this.CartDetails = products;
            }
        }
       

        private void UpdatePrice()
        {
            this.ResetPriceValue();

            if (this.CartDetails != null && this.CartDetails.Count > 0)
            {
                foreach (var cartDetail in this.CartDetails)
                {
                    if (cartDetail.totalQuantity == 0)
                    {
                        cartDetail.totalQuantity = 1;
                    }

                    this.TotalPrice += cartDetail.actualPrice * cartDetail.totalQuantity;
                    this.DiscountPrice += cartDetail.discountPrice * cartDetail.totalQuantity;
                    this.percent += cartDetail.discountPercent;
                }

                this.DiscountPercent = this.percent > 0 ? this.percent / this.CartDetails.Count : 0;
            }
        }

        private void ResetPriceValue()
        {
            this.TotalPrice = 0;
            this.DiscountPercent = 0;
            this.DiscountPrice = 0;
            this.percent = 0;
        }

        #endregion
    }
}
