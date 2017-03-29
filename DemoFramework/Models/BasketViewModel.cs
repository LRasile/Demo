using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoFramework.Models
{
    public class BasketViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        [Required, DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime DeliveryDate { get; set; }

        [Required, DataType(DataType.Time)]
        public TimeSpan DeliveryTime { get; set; }

        [Required, DataType(DataType.Html)]
        public string HtmlInput { get; set; }

        [Required, DataType(DataType.CreditCard)]
        public string CreditCard { get; set; }

        [Required, DataType(DataType.Duration)]
        public string Duration { get; set; }

        //public IList<ProductViewModel> ProductList { get; set; }
    }
}