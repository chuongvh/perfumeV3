using S3.Train.WebPerFume.Areas.Admin.Models;
using S3Train.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3.Train.WebPerFume.Models
{
    public class Products
    {
        public Guid Id { get; set; }

        [Display(Name = "Vendor")]
        public Guid Vendor_Id { get; set; }

        [Display(Name = "Brand")]
        public Guid Brand_Id { get; set; }

        [Display(Name = "Name")]
        [UIHint("FormControlTextBox")]
        [Required]
        public string Name { get; set; }

        [UIHint("FormControlTextBox")]
        [Required]
        [AllowHtml]
        public string Description { get; set; }


        [Display(Name = "Image")]
        [Required]
        public string ImagePath { get; set; }

        public virtual Vendor Vendor { get; set; }
        public virtual Brand Brand { get; set; }
    }
}