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
    public partial class AddAddressess : ContentPage
    {
        public AddAddressess()
        {
            InitializeComponent(); 
        }

        private void cls1_defaultAddress(object sender, EventArgs e)
        {
            btn_Yes.TextColor =Color.White;
            btn_Yes.BackgroundColor = Color.Green;
            btn_No.TextColor = Color.Black;
            btn_No.BackgroundColor = Color.White;
            default_Address_label.Text = "This address is default shipping address";
            default_Address_label.TextColor= Color.Green;
        }

        private void cls2_defaultAddress(object sender, EventArgs e)
        {
            btn_No.TextColor = Color.White;
            btn_No.BackgroundColor = Color.Green;
            btn_Yes.TextColor = Color.Black;
            btn_Yes.BackgroundColor = Color.White;
            default_Address_label.Text = "This is NOT default shipping address";
            default_Address_label.TextColor = Color.Gray;
        }
    }
}