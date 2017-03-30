using System;
using System.ComponentModel.DataAnnotations;

namespace DemoFramework.Models
{
    public class ProductViewModel
    {
        [Required, Range(0,Int32.MaxValue)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}