using E_commerce_App.Models;
using E_commerce_App.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace E_commerce_App.ViewModels
{
    public class AddedAddressDetailsViewModel :BaseViewModel
    {
        #region Fields

        SharedPreferences sharedPreferences;
        User currentUser;
        ServerRequests serverRequests;
        private string defaultAddressLabel;
        private bool defAddIsVisible;
        private Address defaultAddressObj;
        private bool additionalAddressesIsVisible;
        private ObservableCollection<Address> addressesList;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginWithSocialIconViewModel" /> class.
        /// </summary>
        public AddedAddressDetailsViewModel()
        {
            this.AddAddressCommand = new Command(this.AddAddressButton);
            sharedPreferences = SharedPreferences.Instance;
            currentUser = sharedPreferences.CurrentUserInfo;
            serverRequests = new ServerRequests();
            defAddIsVisible= false;
            additionalAddressesIsVisible= false;
            defaultAddressLabel = "There is No Default Address";
            addressesList = new ObservableCollection<Address>();
            foreach (var item in currentUser.address)
            {
                if (item.defaultAddress == false)
                {
                    additionalAddressesIsVisible = true;
                    addressesList.Add(item);
                }
                else 
                {
                    defaultAddressLabel = "Default Address";
                    defAddIsVisible = true;
                    defaultAddressObj = item;
                }
            }

        }


        #endregion

        #region property

        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public string DefaultAddressLabel
        {
            get
            {
                return this.defaultAddressLabel;
            }


            set
            {
                if (this.defaultAddressLabel == value)
                {
                    return;
                }

                this.SetProperty(ref this.defaultAddressLabel, value);
            }


        }
        public bool DefAddIsVisible
        {
            get
            {
                return this.defAddIsVisible;
            }


            set
            {
                if (this.defAddIsVisible == value)
                {
                    return;
                }

                this.SetProperty(ref this.defAddIsVisible, value);
            }
        }
        public Address DefaultAddressObj
        {
            get
            {
                return this.defaultAddressObj;
            }


            set
            {
                if (this.defaultAddressObj == value)
                {
                    return;
                }

                this.SetProperty(ref this.defaultAddressObj, value);
            }
        }
        public bool AdditionalAddressesIsVisible
        {
            get
            {
                return this.additionalAddressesIsVisible;
            }


            set
            {
                if (this.additionalAddressesIsVisible == value)
                {
                    return;
                }

                this.SetProperty(ref this.additionalAddressesIsVisible, value);
            }
        }
        public ObservableCollection<Address> AddressesList
        {
            get
            {
                return this.addressesList;
            }


            set
            {
                if (this.addressesList == value)
                {
                    return;
                }

                this.SetProperty(ref this.addressesList, value);
            }
        }



        #endregion

        #region Command

        public Command AddAddressCommand { get; set; }

        public Command DefaultAddressCommand { get; set; }


        public Command AdditionalAddressCommand { get; set; }
        #endregion

        #region methods

        private void AddAddressButton(object sender)
        {
            Shell.Current.Navigation.PushAsync(new Views.AddAddressess());
        }
        #endregion
    }
}
