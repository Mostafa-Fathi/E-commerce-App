using E_commerce_App.Models;
using E_commerce_App.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace E_commerce_App.ViewModels
{
    public class AddAddressViewModel : BaseViewModel
    {
        #region Fields

        SharedPreferences sharedPreferences;
        User currentUser;
        private string firstName = "";
        private string lastName = "";
        private string state = "";
        private string country = "";
        private string street = "";
        private bool isDefAdd;
        private string phone = "";
        private Color yesBtnColor;
        private Color noBtnColor;
        private Color yesBgBtnColor;
        private Color noBgBtnColor;
        private Color labelColor;
        private string labeltext;
        ServerRequests serverRequests;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginWithSocialIconViewModel" /> class.
        /// </summary>
        public AddAddressViewModel()
        {
            this.AddAddressCommand = new Command(this.AddAddressButtonAsync);
            this.DefaultAddressCommand = new Command(this.DefaultAddressButton);
            this.AdditionalAddressCommand = new Command(this.AdditionalAddressButton);
            noBtnColor = Color.White;
            noBgBtnColor = Color.Green;
            yesBtnColor = Color.Black;
            yesBgBtnColor = Color.White;
            labeltext = "This is NOT default shipping address";
            labelColor = Color.Gray;
            sharedPreferences = SharedPreferences.Instance;
            currentUser = sharedPreferences.CurrentUserInfo;
            isDefAdd = false;
            serverRequests = new ServerRequests();
        }


        #endregion

        #region property

        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public string FirstName
        {
            get
            {
                return this.firstName;
            }


            set
            {
                if (this.firstName == value)
                {
                    return;
                }

                this.SetProperty(ref this.firstName, value);
            }


        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }


            set
            {
                if (this.lastName == value)
                {
                    return;
                }

                this.SetProperty(ref this.lastName, value);
            }
        }
        public string Phone
        {
            get
            {
                return this.phone;
            }


            set
            {
                if (this.phone == value)
                {
                    return;
                }

                this.SetProperty(ref this.phone, value);
            }
        }
        public string Country
        {
            get
            {
                return this.country;
            }


            set
            {
                if (this.country == value)
                {
                    return;
                }

                this.SetProperty(ref this.country, value);
            }
        }
        public string State
        {
            get
            {
                return this.state;
            }


            set
            {
                if (this.state == value)
                {
                    return;
                }

                this.SetProperty(ref this.state, value);
            }
        }

        public string Street
        {
            get
            {
                return this.street;
            }


            set
            {
                if (this.street == value)
                {
                    return;
                }

                this.SetProperty(ref this.street, value);
            }
        }
        public Color YesBtnColor
        {
            get
            {
                return this.yesBtnColor;
            }


            set
            {
                if (this.yesBtnColor == value)
                {
                    return;
                }

                this.SetProperty(ref this.yesBtnColor, value);
            }
        }
        public Color NoBtnColor
        {
            get
            {
                return this.noBtnColor;
            }


            set
            {
                if (this.noBtnColor == value)
                {
                    return;
                }

                this.SetProperty(ref this.noBtnColor, value);
            }
        }

        public Color YesBgBtnColor
        {
            get
            {
                return this.yesBgBtnColor;
            }


            set
            {
                if (this.yesBgBtnColor == value)
                {
                    return;
                }

                this.SetProperty(ref this.yesBgBtnColor, value);
            }
        }
        public Color NoBgBtnColor
        {
            get
            {
                return this.noBgBtnColor;
            }


            set
            {
                if (this.noBgBtnColor == value)
                {
                    return;
                }

                this.SetProperty(ref this.noBgBtnColor, value);
            }
        }
        public Color LabelColor
        {
            get
            {
                return this.labelColor;
            }


            set
            {
                if (this.labelColor == value)
                {
                    return;
                }

                this.SetProperty(ref this.labelColor, value);
            }
        }


        public string LabelText
        {
            get
            {
                return this.labeltext;
            }


            set
            {
                if (this.labeltext == value)
                {
                    return;
                }

                this.SetProperty(ref this.labeltext, value);
            }
        }

        #endregion

        #region Command

        public Command AddAddressCommand { get; set; }

        public Command DefaultAddressCommand { get; set; }


        public Command AdditionalAddressCommand { get; set; }
        #endregion

        #region methods

        
        private async void AddAddressButtonAsync(object sender)
        {
            if (Phone != String.Empty && Country != String.Empty && State != String.Empty && FirstName != String.Empty && LastName != String.Empty && Street != String.Empty)
            {
                Regex RegexPhone = new Regex("^01[0-2,5]{1}[0-9]{8}$");
                if (RegexPhone.IsMatch(Phone))
                {

                    Address address = new Address();
                    address.phone = Phone;
                    address.state = State;
                    address.country = Country;
                    address.street = Street;
                    Name name = new Name();
                    name.firstname = FirstName;
                    name.lastname = LastName;
                    address.name = name;
                    address.defaultAddress = isDefAdd;
                    currentUser.address.Add(address);
                    bool result = await serverRequests.UpdateUserData(currentUser);
                    if (result == true)
                    {
                        if (isDefAdd)
                        { 
                        for (int i = 0; i < currentUser.address.Count-1; i++)
                        {
                            currentUser.address[i].defaultAddress = false;
                        }
                        }
                        await serverRequests.UpdateUserData(currentUser);
                        sharedPreferences.CurrentUserInfo=currentUser;
                        await App.Current.MainPage.DisplayAlert("Done", "Address added successfully", "OK");
                        await Shell.Current.Navigation.PopToRootAsync();
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "SomeThing Went Wrong Check Internet Connection", "OK");
                        currentUser.address.Remove(currentUser.address[currentUser.address.Count]);
                    }

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Wrong Phone Number ", "You enter right phone number ", "ok");
                }
            }
            else
            {
               await App.Current.MainPage.DisplayAlert("Wrong Input ", "You Must Compelte All input fields", "ok");
            }
        }

        private void DefaultAddressButton(object sender)
        {
            YesBtnColor = Color.White;
            YesBgBtnColor = Color.Green;
            NoBtnColor = Color.Black;
            NoBgBtnColor = Color.White;
            LabelText = "This address is default shipping address";
            LabelColor = Color.Green;
            isDefAdd = true;

        }

        private void AdditionalAddressButton(object sender)
        {
            NoBtnColor = Color.White;
            NoBgBtnColor = Color.Green;
            YesBtnColor = Color.Black;
            YesBgBtnColor = Color.White;
            LabelText = "This is NOT default shipping address";
            LabelColor = Color.Gray;
            isDefAdd = false;
        }

        #endregion

    }
}
