using E_commerce_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_commerce_App.Views.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class Products : ContentPage
{
    public Products()
    {
        InitializeComponent();
        BindingContext = new ProductVM();
    }
}
}