using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreFront.DATA;
using System.ComponentModel.DataAnnotations;

namespace StoreFront.Models
{
    public class CartItemViewModel
    {
        [Range(1, int.MaxValue)]
        public int Quanity { get; set; }
        public Game Product { get; set; }

        //ctor
        public CartItemViewModel(int quanity, Game product)
        {
            //props
            Quanity = quanity;
            Product = product;
        }
    }//end class
}//end namespace