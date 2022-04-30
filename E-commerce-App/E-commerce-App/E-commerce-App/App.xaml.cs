using E_commerce_App.View.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_commerce_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new E_commerce_App.View.TabContainer();
            MainPage = new Categories();
            //MainPage = new Products();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
