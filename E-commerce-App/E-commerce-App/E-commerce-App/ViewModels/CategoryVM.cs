using E_commerce_App.Models;
using E_commerce_App.Services;
using E_commerce_App.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace E_commerce_App.ViewModel
{
    public class CategoryVM:INotifyPropertyChanged
{
        private ObservableCollection<Category> categoriesList;
        private ServerRequests httpClient;
        private Category selectedCategory;
        public INavigation Navigation { get; set; }
        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set { selectedCategory = value; 
            onPropertyChanged();
              
            }
        }
     

        public event PropertyChangedEventHandler PropertyChanged;
        void onPropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Category> CategoriesList
        {
            get { return categoriesList; }
            set { 
                categoriesList = value;
                onPropertyChanged();
            }
        }
        // TODO: Filter Categories Function
        public CategoryVM()
        {
            httpClient = new ServerRequests();
            CategoriesList = new ObservableCollection<Category>()
            {
               new Category(){name="Loading"}
            };
            loadData();
        }
        private async void loadData()
        {
            CategoriesList = await httpClient.GetCategories();  
        }

    }
}
