using E_commerce_App.ViewModel;
using Syncfusion.ListView.XForms;
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
    public partial class Categories : ContentPage
    {
        public UserVM userVM;
        public Categories()
        {
            InitializeComponent();
            BindingContext = new CategoryVM();
            userVM = new UserVM();
        }
        public async void  Login()
        {
            string name= await userVM.Login();
            await DisplayAlert(name, "jajaj", "ok");

        }

        private void aaaa(object sender, EventArgs e)
        {
            userVM.UserName = "mor_2314";
            userVM.UserPassword = "83r5^_";
            Login();
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width < height)
            {
                if (this.CategoryTile.LayoutManager is GridLayout)
                {
                    (this.CategoryTile.LayoutManager as GridLayout).SpanCount = 2;
                }
            }
            else
            {
                if (this.CategoryTile.LayoutManager is GridLayout)
                {
                    (this.CategoryTile.LayoutManager as GridLayout).SpanCount = 3;
                }
            }
        }
    }
}