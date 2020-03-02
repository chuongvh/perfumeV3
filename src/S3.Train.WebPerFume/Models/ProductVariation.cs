using S3.Train.WebPerFume.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3.Train.WebPerFume.Models
{
    public class ProductVariation
    {
        public Guid Id { get; set; }
        
        public Guid Product_Id { get; set; }

        public ProductImageModel Image { get; set; }

        [Display(Name = "Discounrt Price")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal DiscountPrice { get; set; }

        public string SKU { get; set; }

        public string Volume { get; set; }

        [Display(Name = "Quantity")]
        public decimal StockQuantity { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal Price { get; set; }

        [Display(Name = "Product")]
        public List<SelectListItem> DropDownProduct { get; set; }

        [Display(Name = "Volume")]
        public List<SelectListItem> DropDownVolume { get; set; }
    }
}