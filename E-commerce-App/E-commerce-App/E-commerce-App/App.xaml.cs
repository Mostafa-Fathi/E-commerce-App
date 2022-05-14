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
        public static string ImageServerPath { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";
        public App()
        {
            InitializeComponent();



            MainPage = //new Views.EmptyWishList();
                //new Views.AddedAddressDetails();
            new NavigationPage(new Views.AccountDetails());
           //new Views.AccountDetails();
            //new Categories();
            //new Products();
            //new Views.SignUpPage();
            //new Views.LoginwithSocialIconPage();
            //new E_commerce_App.Views.TabContainer();
            //new Views.SignUpPage();
            //new Cart();
            //new Views.LoginwithSocialIconPage();
            //new E_commerce_App.Views.CategoryTilePage();
           //new E_commerce_App.Views.ProductTilePage();
           //new E_commerce_App.Views.DetailPage();
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
