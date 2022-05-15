using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce_App.Models
{
    public class Cart
    {
        public int id { get; set; }
        public int userId { get; set; }

        public DateTime date { get; set; }

        public List<CartProductItem> products { get; set; }

    }
}
