using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S3.Train.WebPerFume.Areas.Admin.Models
{
    public class ProductVariationViewModel
    {
        public Guid Id { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsActive { get; set; }

        public string ImagePath { get; set; }

        [Display(Name = "Discounrt Price")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal DiscountPrice { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        public string SKU { get; set; }

        public string Volume { get; set; }

        [Display(Name = "Quantity")]
        public decimal StockQuantity { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal Price { get; set; }

        public ProductImagePost Image { get; set; }
    }


    public class ProductImagePost
    {
        public Guid Id { get; set; }
        public Guid ProducVariation_Id { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }


}