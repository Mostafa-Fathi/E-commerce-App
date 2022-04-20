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
        private ObservableCollection<String> categoriesList;
        private ServerRequests httpClient;
        public event PropertyChangedEventHandler PropertyChanged;
        void onPropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<String> CategoriesList
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
            loadData();
            CategoriesList = new ObservableCollection<String>()
            {
                "Loading..."
            };


        }
        private async void loadData()
        {
            CategoriesList = await httpClient.GetCategories();
        }

    }
}
