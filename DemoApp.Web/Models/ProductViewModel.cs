using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Web.Models
{
    public class ProductViewModel
    {
        [Key]
        public int? PId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Manufacturer")]
        public string Manufacturer { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        [Range(1,1000)]
        public int? Quantity { get; set; }

        [Required]
        [Display(Name = "Rate")]
        public decimal? Rate { get; set; }

        [Display(Name = "Total Amount")]
        public decimal? TotalAmount { get; set; }

        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; }

        [Display(Name = "Modified On")]
        public DateTime? LastModifiedOn { get; set; }


    }
}
