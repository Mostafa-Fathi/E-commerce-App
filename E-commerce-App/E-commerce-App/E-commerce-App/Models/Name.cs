using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce_App.Models
{
    public class Name
    {
        public string firstname { get; set; }
        public string lastname { get; set; }

        public override string ToString()
        {
            return firstname + lastname;
        }
    }
}
