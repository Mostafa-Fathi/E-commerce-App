using System;
using System.Collections.Generic;
using System.Text;

namespace  E_commerce_App.Models

{
    public class Address
    {
        public string city { get; set; }
        public string street { get; set; }

        public string zipcode { get; set; }

        public int number { get; set; }
        public Geolocation geolocation { get; set; }
    }
}
