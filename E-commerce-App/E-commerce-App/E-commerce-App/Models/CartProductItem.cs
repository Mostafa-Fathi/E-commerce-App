using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce_App.Models
{
    public class CartProductItem : Product
    {
        //public Product product { get; set; }
        public int quantity { get; set; } = 1;
        public void plusQuantity()
        {
            quantity++;
        }
        public void minusQuantity()
        {
            quantity--;
        }
    }

}
