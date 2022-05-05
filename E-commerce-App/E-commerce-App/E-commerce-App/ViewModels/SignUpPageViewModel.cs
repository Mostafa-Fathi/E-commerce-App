using E_commerce_App.Models;
using E_commerce_App.Services;
using E_commerce_App.Validators;
using E_commerce_App.Validators.Rules;
using E_commerce_App.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace E_commerce_App.ViewModels
{
    /// <summary>
    /// ViewModel for sign-up page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SignUpPageViewModel : LoginViewModel
    {
        User user;

        #region Fields

        private ValidatableObject<string> name;

        private ValidatablePair<string> password;
        //added by hadeer
        private ValidatableObject<string> phone;
        private ValidatableObject<string> sname;
        private ServerRequests httpClient;
        private bool isRunning;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="SignUpPageViewModel" /> class.
        /// </summary>
        public SignUpPageViewModel()
        {
            this.InitializeProperties();
            this.AddValidationRules();
            httpClient = new ServerRequests();
            this.LoginCommand = new Command(this.LoginClicked);
            this.SignUpCommand = new Command(this.SignUpClickedAsync);
            IsRunning = false;
            

        }
        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the name from user in the Sign Up page.
        /// </summary>
        public ValidatableObject<string> Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name == value)
                {
                    return;
                }

                this.SetProperty(ref this.name, value);
            }
        }
        //added by hadder
        public ValidatableObject<string> SName
        {
            get
            {
                return this.sname;
            }

            set
            {
                if (this.sname == value)
                {
                    return;
                }

                this.SetProperty(ref this.sname, value);
            }
        }
        //added by hadeer
        public ValidatableObject<string> Phone
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
        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the password from users in the Sign Up page.
        /// </summary>
        public ValidatablePair<string> Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password == value)
                {
                    return;
                }

                this.SetProperty(ref this.password, value);
            }
        }
        public bool IsRunning
        {
            get
            {
                return this.isRunning;
            }

            set
            {
                if (this.isRunning == value)
                {
                    return;
                }

                this.SetProperty(ref this.isRunning, value);
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }


        #endregion

        #region Methods

        /// <summary>
        /// Initialize whether fieldsvalue are true or false.
        /// </summary>
        /// <returns>true or false </returns>
        public bool AreFieldsValid()
        {
            bool isEmail = this.Email.Validate();
            bool isNameValid = this.Name.Validate();
            bool isSNameValid = this.SName.Validate();
            bool isPhone = this.Phone.Validate();
            bool isPasswordValid = this.Password.Validate();
            return isPasswordValid && isNameValid && isEmail && isSNameValid && isPhone;
        }

        /// <summary>
        /// Initializing the properties.
        /// </summary>
        private void InitializeProperties()
        {
            this.Name = new ValidatableObject<string>();
            this.SName = new ValidatableObject<string>();
            this.Password = new ValidatablePair<string>();
            this.Phone = new ValidatableObject<string>();
        }

        /// <summary>
        /// this method contains the validation rules
        /// </summary>
        private void AddValidationRules()
        {
            this.Name.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "First Name Required" });
            this.SName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Second Name Required" });
            this.Phone.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Phone Required" });
            this.Password.Validations.Add(new MatchPairValidationRule<string> { ValidationMessage = "Confirm Password is Wrong" });
            this.Password.Item2.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Enter Confirm Password" });
            this.Password.Item1.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Enter Password" });
            this.Password.Item1.Validations.Add(new IsValidPasswordRule<string> { ValidationMessage = "Password between 8-20 characters; must contain at least one lowercase letter, one uppercase letter, one numeric digit, and one special character" });


        }

        /// <summary>
        /// Invoked when the Log in button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void LoginClicked(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new LoginwithSocialIconPage());
            // Do something
        }

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void SignUpClickedAsync(object obj)
        {
            if (this.AreFieldsValid())
            {
                IsRunning = true;
                if (await IsEmailExists())
                {

                    user = new User();
                    user.name.firstname = Name.Value;
                    user.name.lastname = SName.Value;
                    user.email = Email.Value;
                    user.phone = Phone.Value;
                    user.username = await generateUserName();
                    user.password = Password.Item1.Value;
                    if (await httpClient.SignUp(user))
                    {
                       IsRunning = false;

                        // will be deleted 
                        // TODO : Go to home page
                        // TODO : manual login
                        await App.Current.MainPage.DisplayAlert("Scuuses", "This Email is Already Exits Do You Forget Your Password", "Yes", "Not my Email");

                    }
                    else {
                        IsRunning = false;
                        await App.Current.MainPage.DisplayAlert("Network Error", "Check you network", "OK");

                    }
                }
                else
                {
                    IsRunning= false;
                    // TODO : Forget password =>  go to reset password screen.
                    // TODO : Not My Email => Stay at the same page.
                    await App.Current.MainPage.DisplayAlert("Exists Email", "This Email is Already Exits", "Forget Password", "Not my Email");

                }

            }
        }

        private async Task<bool> IsEmailExists()
        {

            User currentUser = await httpClient.CheckEmail(Email.Value);
            if (currentUser == null)
            {
                return true;
            }
            else return false;

        }
        private async Task<string> generateUserName()
        {
            String generatedUserName;

            do { generatedUserName = user.name.ToString() + new Random().Next(0, 9) + new Random().Next(0, 9) + new Random().Next(0, 9); }
            while (await CheckUserNameValid(generatedUserName));
            return generatedUserName;
        }

        private async Task<bool> CheckUserNameValid(String testUserName)
        {
            User CurrentUser = await httpClient.Login(testUserName);
            return CurrentUser == null ? false : true;
        }
        // we need to vaild email 


        //private async Task<bool> validEmailAsync() {
        //   User CurrentUser = await httpClient.Login();

        //    if () { }
        //    else
        //}

        #endregion
    }
}