﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3.Train.WebPerFume.Areas.Admin.Models
{
    public class ProVarationViewModel
    {
        public Guid Id { get; set; }

        public Guid Product_Id { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsActive { get; set; }

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


    public class ProductImageModel
    {
        public Guid Id { get; set; }
        public Guid ProducVariation_Id { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class ProductModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public List<ProVarationViewModel> proVarationViewModels { get; set; }
    }
}