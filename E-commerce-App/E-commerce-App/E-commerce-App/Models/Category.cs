using System.Collections.Generic;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;
using System.Text;
using System;

namespace E_commerce_App.Models
{
    /// <summary>
    /// Model for category.
    /// </summary>

    public class Category
    {

        private bool isSelected; 
        public bool IsSelected
        {
            get { return this.isSelected; }

            set { this.isSelected = value; }
        }

        public string name { set; get; }
        public Uri img { set; get; }
    }
}