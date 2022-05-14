using System;
using System.Collections.Generic;
using System.Text;

namespace  E_commerce_App.Models

{
    public class Address
    {
        public string state { get; set; }
        public string street { get; set; }
        
        public Name name { get; set; }
        public string country { get; set; }

        public string phone { get; set; }
        public bool defaultAddress { get; set; }
    }
}
