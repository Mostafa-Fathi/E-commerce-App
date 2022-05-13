using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce_App.Models
{
    public class Product
{
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public string category { get; set; }
        public Uri image { get; set; }
        public Rating rating { get; set; }
     // aaaaaa
        public int totalQuantity { get; set; }
        public bool isFavourite { get; set; }
        public int actualPrice { get; set; }
        public int discountPercent { get; set; }
        public int discountPrice { get; set; }
       // lllllll
        public override string ToString()
        {
            return $"product title is : {title} \nproduct description is :{description}";
        }

    }
}
