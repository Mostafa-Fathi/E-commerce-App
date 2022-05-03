using E_commerce_App.Models;
using E_commerce_App.Services;
using E_commerce_App.Validators;
using E_commerce_App.Validators.Rules;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace E_commerce_App.ViewModels
{
    /// <summary>
    /// ViewModel for login with social icon page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class LoginWithSocialIconViewModel : LoginViewModel, INotifyPropertyChanged
    {
        private User currentUser;
        private string userName;
        private string userPassword;
        private bool isloading;

        public bool isLoading
        {
            get { return isloading; }
            set { isloading = value;
                OnChangeProperty();
                LoginCommand.ChangeCanExecute();
            }
        }

        public Command LoginCommand { get;}

        public string UserPassword
        {
            get { return userPassword; }
            set { userPassword = value; }
        }


        public string UserName
        {
            get { return userName; }
            set { userName = value;
                OnChangeProperty();
            }
        }


        public User CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }

        private ServerRequests httpClient;



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnChangeProperty([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public LoginWithSocialIconViewModel()
        {
            httpClient = new ServerRequests();

            LoginCommand = new Command(async () =>await Login(),()=> !isLoading);

        }
        public async Task<string> Login()
        {
            // 83r5^_  username: mor_2314
            isLoading = true;
            CurrentUser = await httpClient.Login(UserName);
            isLoading = false;
            if (currentUser == null)
            {
              
                return "User not found";
            }
            if (!(CurrentUser.password.ToLower().Equals(userPassword?.ToLower())))
            {
               
                return "Wrong password";
            }
           // UserName = CurrentUser.username;
            return CurrentUser.username;
        }


    }

}
