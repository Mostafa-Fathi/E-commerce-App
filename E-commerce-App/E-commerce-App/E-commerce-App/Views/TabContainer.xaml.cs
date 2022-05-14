using E_commerce_App.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_commerce_App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class TabContainer : Shell
{
    public TabContainer()
    {
        InitializeComponent();
            Routing.RegisterRoute("Categories", typeof(Categories));
    }
}
}