using System;
using System.ComponentModel.DataAnnotations;

namespace MvcGridTest.Models
{
    public class ProductViewModel
    {
        [Required]
        [Range(0,Int32.MaxValue)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^\\d*(\\.\\d{2})$")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public double Price { get; set; }
    }
}