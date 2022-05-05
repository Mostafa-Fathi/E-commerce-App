using E_commerce_App.Models;
using E_commerce_App.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace E_commerce_App.ViewModel
{
    public class CategoryVM:INotifyPropertyChanged
{
        private ObservableCollection<Category> categoriesList;
        private ServerRequests httpClient;
        public event PropertyChangedEventHandler PropertyChanged;
        void onPropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
        private string test;

        public string Test
        {
            get { return test; }
            set { 
                test = value;
                onPropertyChanged();
            }
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
               new Category(){name="Loading",img=""}
            };
            loadData();
        }
        private async void loadData()
        {
            Test = "Before";
            CategoriesList = await httpClient.GetCategories();  
            Test = CategoriesList[0].name;
        }

    }
}
