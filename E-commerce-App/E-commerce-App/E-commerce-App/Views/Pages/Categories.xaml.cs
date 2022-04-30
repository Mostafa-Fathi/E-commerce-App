using E_commerce_App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using E_commerce_App.ViewModels;
using E_commerce_App.ViewModel;
namespace E_commerce_App.Views.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class Categories : ContentPage
{
    UserVM vm;
    public Categories()
    {
        InitializeComponent();
             BindingContext = new CategoryVM();
           
    }
    }
}