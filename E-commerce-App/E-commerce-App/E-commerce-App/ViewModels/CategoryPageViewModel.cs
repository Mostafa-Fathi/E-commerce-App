using E_commerce_App.Models;
using E_commerce_App.Services;
using E_commerce_App.Views;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace E_commerce_App.ViewModels
{
    /// <summary>
    /// ViewModel for Category page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class CategoryPageViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<Category> categoriesList = new ObservableCollection<Category> {                new Category(){name="Loading",img=new System.Uri("https://www.industrialempathy.com/img/remote/ZiClJf-1920w.jpg")}
};
        private ServerRequests httpClient;
        private Command categorySelectedCommand;

        private Command notificationCommand;

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the property that has been bound with StackLayout, which displays the categories using ComboBox.
        /// </summary>
        [DataMember(Name = "categoriesList")]
        public ObservableCollection<Category> CategoriesList
        {
            get { return categoriesList; }
            set
            {
                categoriesList = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region
        public CategoryPageViewModel()
        {
            httpClient = new ServerRequests();
            CategoriesList = new ObservableCollection<Category>()
            {
               new Category(){name="Loading"}
            };
            loadData();
        }
        #endregion

        #region Command

        /// <summary>
        /// Gets the command that will be executed when the Category is selected.
        /// </summary>
        public Command CategorySelectedCommand
        {
            get { return this.categorySelectedCommand ?? (this.categorySelectedCommand = new Command(this.CategorySelected)); }
        }

        /// <summary>
        /// Gets the command that will be executed when the Notification button is clicked.
        /// </summary>
        public Command NotificationCommand
        {
            get { return this.notificationCommand ?? (this.notificationCommand = new Command(this.NotificationClicked)); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the Category is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void CategorySelected(object obj)
        {
            // Do Something
            Category category = (Category)obj;
           // await Application.Current.MainPage.DisplayAlert(category.name, "","ok");
            await Application.Current.MainPage.Navigation.PushAsync(new ProductTilePage(category.name));
        }

        /// <summary>
        /// Invoked when the notification button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void NotificationClicked(object obj)
        {
            // Do something
        }
        private async void loadData()
        {
            CategoriesList = await httpClient.GetCategories();
        }
        #endregion
    }
}