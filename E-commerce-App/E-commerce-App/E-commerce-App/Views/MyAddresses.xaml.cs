﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_commerce_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAddresses : ContentPage
    {
        public MyAddresses()
        {
            InitializeComponent();
        }

        private void AddAddressesPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddAddressess());
        }
    }
}