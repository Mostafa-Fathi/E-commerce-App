using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace E_commerce_App.Models
{
    public class User
    {


       public User() {
            name = new Name();
            address = new ObservableCollection<Address>();
        }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public Name name { get; set; }
        public ObservableCollection<Address> address { get; set; }
        public string phone { get; set; }
        public int id { get; set; }

    }
}
