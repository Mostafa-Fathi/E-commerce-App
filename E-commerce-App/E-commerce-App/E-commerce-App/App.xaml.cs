using E_commerce_App.Views.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Montserrat-Bold.ttf",Alias="Montserrat-Bold")]
     [assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat-Medium")]
     [assembly: ExportFont("Montserrat-Regular.ttf", Alias = "Montserrat-Regular")]
     [assembly: ExportFont("Montserrat-SemiBold.ttf", Alias = "Montserrat-SemiBold")]
     [assembly: ExportFont("UIFontIcons.ttf", Alias = "FontIcons")]
namespace E_commerce_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new E_commerce_App.View.TabContainer();
            //MainPage = new Categories();
            //MainPage = new Products();
            MainPage =
                       //new Views.SignUpPage();
                //new Cart();
                //new Views.LoginwithSocialIconPage();
                new E_commerce_App.Views.TabContainer();
                //MainPage = new Categories();
                // MainPage = new Products();
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
